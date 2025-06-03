namespace TicketService.Models.RequestModels
{
    public class ValidateTicketRequest
    {
        public required string Code { get; set; }
        public int Status { get; set; }
    }
}
