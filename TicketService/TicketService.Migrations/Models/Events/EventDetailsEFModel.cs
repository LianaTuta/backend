namespace TicketService.Migrations.Models.Events
{
    public class EventDetailsEFModel
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public int EventId { get; set; }
        public required EventEFModel Event { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
