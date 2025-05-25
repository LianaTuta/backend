namespace TicketService.Models.Configuration
{
    public class StripeCredentials
    {

        public required string SecretKey { get; set; }
        public required string PublishableKey { get; set; }
        public required string WebhookSecret { get; set; }

    }
}
