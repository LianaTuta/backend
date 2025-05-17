namespace TicketService.Models.Configuration
{
    public class PayPalSettings
    {
        public required string ClientId { get; set; }
        public required string Secret { get; set; }
        public required string Mode { get; set; }
    }
}
