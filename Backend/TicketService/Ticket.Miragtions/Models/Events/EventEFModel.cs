namespace TicketService.Migrations.Models.Events
{
    public class EventEFModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int EventTypeId { get; set; }
        public required EventTypeEFModel EventType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
