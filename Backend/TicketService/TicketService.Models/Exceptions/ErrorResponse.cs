namespace TicketService.Models.Exceptions
{
    public class ErrorResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
