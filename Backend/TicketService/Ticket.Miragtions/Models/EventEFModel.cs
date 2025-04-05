namespace TicketService.Migrations.Models
{
    public class EventEFModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EventTypeId { get; set; }
        public required EventTypeEFModel EventType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }


    }
}
