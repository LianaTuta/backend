namespace TicketService.Models.RequestModels.Event
{
    public class EventDetailsRequest
    {
        public required string Description { get; set; }
        public required string Location { get; set; }
        public int EventId { get; set; }
    }
}
