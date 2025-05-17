namespace TicketService.Migrations.Models.Events
{
    public class EventTypeEFModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
