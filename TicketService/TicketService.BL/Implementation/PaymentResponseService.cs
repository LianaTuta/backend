using TicketService.BL.Implementation.Template;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Payments;
using TicketService.Models.Enum;
using TicketService.Models.StripePayment;

namespace TicketService.BL.Implementation
{
    public class PaymenetResponseService : IPaymentResponseService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly PlaceOrderTemplate _placeOrderTemplate;

        public PaymenetResponseService(IPaymentRepository paymentRepository,
            IOrderRepository orderRepository,
            PlaceOrderTemplate placeOrderTemplate)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _placeOrderTemplate = placeOrderTemplate;
        }


        public async Task UpdatePaymentAsync(StripeEvent stripeEvent)
        {

            string paymentId = stripeEvent.Data.Object.PaymentId;
            string sessionStatus = stripeEvent.Data.Object.SessionStatus;
            string paymentStatus = stripeEvent.Data.Object.PaymentStatus;
            Console.WriteLine(sessionStatus, paymentStatus, paymentId, paymentStatus);
            PaymentModel payment = await _paymentRepository.GetUserPaymentbyPaymentKeyAsync(paymentId);
            await _paymentRepository.UpdateUserPaymentStatusAsync(payment.Id, (int)PaymentStatusEnum.Success);

            int checkoutOrderId = await _orderRepository.GetCheckoutOrderByPaymentIdAsync(payment.Id);
            _ = await _placeOrderTemplate.ProcessOrder(payment.UserId, checkoutOrderId);
        }

    }
}
