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

            List<TicketOrderPaymentModel> userticketOrderPayments = [];
            foreach (TicketOrderModel userTicketOrder in userTicketOrders)
            {
                TicketModel ticket = await _ticketRepository.GetTicketByIdAsync(userTicketOrder.TicketId);
                amount += ticket.Price.Value;
                userticketOrderPayments.Add(new TicketOrderPaymentModel()
                {
                    Amount = (double)ticket.Price,
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
                    Amount = (decimal)amount
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

        public async Task<OrderResponseModel?> CreateRefundPaymentAsync(int userId, int checkoutOrderId)
        {
            PaymentModel payment = await _paymentRepository.GetPaymentByCheckoutOrderIdAsync(checkoutOrderId);

            if (payment != null)
            {
                if (payment.Status == (int)PaymentStatusEnum.Success)
                {
                    _ = _stripePaymentService.CreateRefund(payment.PaymentIntent, (long)payment.Amount * 100);
                    await _paymentRepository.UpdateUserPaymentStatusAsync(payment.Id, (int)PaymentStatusEnum.Refunded);
                }
                else
                {
                    await _paymentRepository.UpdateUserPaymentStatusAsync(payment.Id, (int)PaymentStatusEnum.Expired);
                }
            }
            return null;

        }


        #region

        private SessionCreateOptions CreateSessionCreateOptions(double amount)
        {
            return new()
            {
                Expand = ["payment_intent"],
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
                SuccessUrl = "https://frontend-767515572560.europe-north2.run.app/order-success",
                CancelUrl = "https://frontend-767515572560.europe-north2.run.app/cancel-payment"
            };

        }



        #endregion
    }

}
