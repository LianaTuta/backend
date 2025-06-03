using Stripe;
using Stripe.Checkout;

namespace TicketService.BL.Interface
{
    public interface IStripePaymentService
    {
        Session CreatePayment(SessionCreateOptions createSessionCreate);
        Refund CreateRefund(string paymentIntentId, long amount = 0);
    }
}
