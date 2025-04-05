namespace TicketService.Models.RequestModels.Event
{
    public class AddEventRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EventTypeId { get; set; }
    }
}
