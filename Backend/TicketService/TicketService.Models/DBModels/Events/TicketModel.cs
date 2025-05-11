namespace TicketService.Models.DBModels.Events
{
    public class TicketModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int TicketCategoryId { get; set; }
        public int EventScheduleId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
