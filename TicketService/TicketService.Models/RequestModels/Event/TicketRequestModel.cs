namespace TicketService.Models.RequestModels.Event
{
    public class TicketRequestModel
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int TicketCategoryId { get; set; }
        public int EventScheduleId { get; set; }
        public double Price { get; set; }
        public int NumberOfAvailableTickets { get; set; }
    }
}
