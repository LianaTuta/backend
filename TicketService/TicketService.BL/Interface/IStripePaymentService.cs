using Stripe.Checkout;

namespace TicketService.BL.Interface
{
    public interface IStripePaymentService
    {
        Session CreatePayment(SessionCreateOptions createSessionCreate);
    }
}
