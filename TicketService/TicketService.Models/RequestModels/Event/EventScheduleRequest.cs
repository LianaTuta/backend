namespace TicketService.Models.RequestModels.Event
{
    public class EventScheduleRequest
    {
        public int EventId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
