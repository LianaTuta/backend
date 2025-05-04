namespace TicketService.Models.ResponseModels
{
    public class EventsResponseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int EventTypeId { get; set; }
        public required string ImagePath { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
