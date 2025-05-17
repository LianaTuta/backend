namespace TicketService.Migrations.Models.Events
{
    public class TicketCategoryEFModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
