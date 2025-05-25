using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using TicketService.BL.Interface;
using TicketService.Models.Configuration;

namespace TicketService.BL.Implementation
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly StripeCredentials _stripeCredentials;

        public StripePaymentService(IOptions<StripeCredentials> stripeCredentials)
        {
            _stripeCredentials = stripeCredentials.Value;
        }

        public Session CreatePayment(SessionCreateOptions sessionCreateOptions)
        {
            SessionService service = new();
            Session session = service.Create(sessionCreateOptions);
            return session;
        }

        public void UpdatePayment(Event stripeEvent)
        {
            if (stripeEvent.Type == "checkout.session.completed")
            {
                Session? session = stripeEvent.Data.Object as Session;
                Console.WriteLine($"✅ Payment successful for session: {session?.Id}");
            }
        }
    }
}
