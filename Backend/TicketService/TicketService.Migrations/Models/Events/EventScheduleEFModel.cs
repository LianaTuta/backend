namespace TicketService.Migrations.Models.Events
{
    public class EventScheduleEFModel
    {

        public int Id { get; set; }
        public int EventId { get; set; }
        public required EventEFModel Event { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
