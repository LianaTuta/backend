namespace TicketService.Models
{
    public class JwtSettingsModel
    {
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
        public required string SecretKey { get; set; }
    }
}
