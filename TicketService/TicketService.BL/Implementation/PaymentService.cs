using System.Text.Json;
using Stripe.Checkout;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.Payments;
using TicketService.Models.Enum;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IStripePaymentService _stripePaymentService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;

        public PaymentService(IStripePaymentService stripePaymentService,
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository,
            ITicketRepository ticketRepository)
        {
            _stripePaymentService = stripePaymentService;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;

        }

        public async Task<OrderResponseModel?> CreatePaymentAsync(int userId, int checkoutOrderId)
        {
            PaymentModel payment = await _paymentRepository.GetPaymentByCheckoutOrderIdAsync(checkoutOrderId);
            if (payment != null)
            {
                if (payment.Status == (int)PaymentStatusEnum.Success)
                {
                    return null;
                }
                else
                {
                    if (payment.Status == (int)PaymentStatusEnum.InProgress)
                    {
                        return new OrderResponseModel
                        {
                            ReturnUrl = payment.ReturnUrl,
                            CheckoutOrderId = checkoutOrderId,
                            Step = OrderStep.Payment,
                        };
                    }
                }
            }
            List<TicketOrderModel> userTicketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrderId);
            double amount = 0;

            ///!!!!!!!!!to be changed
            List<TicketOrderPaymentModel> userticketOrderPayments = [];
            foreach (TicketOrderModel userTicketOrder in userTicketOrders)
            {
                TicketModel ticket = await _ticketRepository.GetTicketByIdAsync(userTicketOrder.TicketId);
                amount += ticket.Price.Value;
                userticketOrderPayments.Add(new TicketOrderPaymentModel()
                {
                    Amount = amount,
                    TickerOrderId = userTicketOrder.Id
                });
            }

            if (amount > 0)
            {
                SessionCreateOptions createPaymentSessionRequest = CreateSessionCreateOptions(amount);
                Session paymentSession = await Task.FromResult(_stripePaymentService.CreatePayment(createPaymentSessionRequest));


                PaymentModel userPayment = new()
                {
                    PaymentKey = paymentSession.Id,
                    UserId = userId,
                    Request = JsonSerializer.Serialize(createPaymentSessionRequest),
                    Response = paymentSession.RawJObject.ToString(),
                    CheckoutOrderId = checkoutOrderId,
                    Status = (int)PaymentStatusEnum.InProgress,
                    ReturnUrl = paymentSession.Url,
                    Amount = amount
                };

                int userPaymentId = await _paymentRepository.InsertPaymentAsync(userPayment);

                foreach (TicketOrderPaymentModel userTicketOrderPayment in userticketOrderPayments)
                {
                    userTicketOrderPayment.PaymentId = userPaymentId;
                    userTicketOrderPayment.DateCreated = DateTime.UtcNow;
                    await _paymentRepository.InsertUserTicketOrderPaymentsAsync(userTicketOrderPayment);
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

        #region
        private bool CheckPaymentAsync(int userId, int checkoutOrderId)
        {
            return true;
        }

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
