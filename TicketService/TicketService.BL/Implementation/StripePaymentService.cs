using Stripe;
using Stripe.Checkout;
using TicketService.BL.Interface;

namespace TicketService.BL.Implementation
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly RefundService _refundService;

        public StripePaymentService(RefundService refundService)
        {
            _refundService = refundService;
        }

        public Session CreatePayment(SessionCreateOptions sessionCreateOptions)
        {
            SessionService service = new();
            Session session = service.Create(sessionCreateOptions);
            return session;
        }

        public Refund CreateRefund(string paymentIntentId, long amount = 0)
        {
            RefundCreateOptions options = new()
            {
                PaymentIntent = paymentIntentId,
                Amount = amount,
            };

            return _refundService.Create(options);
        }
    }
}
