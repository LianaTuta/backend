using System.Text.Json;
using Stripe.Checkout;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.Payments;
using TicketService.Models.Enum;
using TicketService.Models.ResponseModels;
using TicketService.Models.StripePayment;

namespace TicketService.BL.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IStripePaymentService _stripePaymentService;
        private readonly IUserPaymentRepository _userPaymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;
        public PaymentService(IStripePaymentService stripePaymentService,
            IUserPaymentRepository userPaymentRepository,
            IOrderRepository orderRepository,
            ITicketRepository ticketRepository)
        {
            _stripePaymentService = stripePaymentService;
            _userPaymentRepository = userPaymentRepository;
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<OrderResponseModel?> CreatePaymentAsync(int userId, int checkoutOrderId)
        {
            List<TicketOrderModel> userTicketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrderId);
            double amount = 0;
            List<UserTicketOrderPayment> userticketOrderPayments = [];
            foreach (TicketOrderModel userTicketOrder in userTicketOrders)
            {
                TicketModel ticket = await _ticketRepository.GetTicketByIdAsync(userTicketOrder.TicketId);
                amount += ticket.Price.Value;
                userticketOrderPayments.Add(new UserTicketOrderPayment()
                {
                    Amount = amount,
                    TickerOrderId = userTicketOrder.Id
                });
            }

            if (amount > 0)
            {
                SessionCreateOptions createPaymentSessionRequest = CreateSessionCreateOptions(amount);
                Session paymentSession = await Task.FromResult(_stripePaymentService.CreatePayment(createPaymentSessionRequest));


                UserPaymentModel userPayment = new()
                {
                    PaymentId = paymentSession.Id,
                    UserId = userId,
                    Request = JsonSerializer.Serialize(createPaymentSessionRequest),
                    Response = paymentSession.RawJObject.ToString(),
                    Status = 1,
                    ReturnUrl = paymentSession.Url,
                    DateCreated = DateTime.UtcNow,
                };

                int userPaymentId = await _userPaymentRepository.InsertPaymentAsync(userPayment);

                foreach (UserTicketOrderPayment userTicketOrderPayment in userticketOrderPayments)
                {
                    userTicketOrderPayment.UserPaymentId = userPaymentId;
                    userTicketOrderPayment.DateCreated = DateTime.UtcNow;
                    await _userPaymentRepository.InsertUserTicketOrderPaymentsAsync(userTicketOrderPayment);
                }

                await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Payment);
                return new OrderResponseModel
                {
                    ReturnUrl = paymentSession.Url,
                    CheckoutOrderId = checkoutOrderId,
                    Step = OrderStep.Payment,
                };
            }
            return null;
        }


        public async Task UpdatePaymentAsync(StripeEvent stripeEvent)
        {

            string paymentId = stripeEvent.Data.Object.PaymentId;
            string sessionStatus = stripeEvent.Data.Object.SessionStatus;
            string paymentStatus = stripeEvent.Data.Object.PaymentStatus;
            Console.WriteLine(sessionStatus, paymentStatus, paymentId, paymentStatus);
            UserPaymentModel payment = await _userPaymentRepository.GetUserPaymentbyPaymentIdAsync(paymentId);
            await _userPaymentRepository.UpdateUserPaymentStatusAsync(payment.Id, 2);
        }

        #region
        private SessionCreateOptions CreateSessionCreateOptions(double amount)
        {
            return new()
            {
                PaymentMethodTypes = ["card"],
                LineItems =
            [
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long?)amount * 100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Tickets Order"
                        }
                    },
                    Quantity = 1
                }
            ],
                Mode = "payment",
                SuccessUrl = "https://frontend-767515572560.europe-north2.run.app/",
                CancelUrl = "https://frontend-767515572560.europe-north2.run.app/"
            };

        }
        #endregion
    }

}
