namespace TicketService.Migrations.Models
{
    public class EventDetailsEFModel
    {
        public int Id { get; set; }
        public int TotalNumberSeats { get; set; }
        public int EventId { get; set; }
        public required EventTypeEFModel Event { get; set; }
    }
}
