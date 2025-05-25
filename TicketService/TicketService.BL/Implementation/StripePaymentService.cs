using Stripe.Checkout;
using TicketService.BL.Interface;

namespace TicketService.BL.Implementation
{
    public class StripePaymentService : IStripePaymentService
    {


        public Session CreatePayment(SessionCreateOptions sessionCreateOptions)
        {
            SessionService service = new();
            Session session = service.Create(sessionCreateOptions);
            return session;
        }
    }
}
