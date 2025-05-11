using TicketService.Migrations.Models.Events;

namespace TicketService.Migrations.Models.User
{
    public class TicketEFModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int TicketCategoryId { get; set; }
        public required TicketCategoryEFModel TicketCategory { get; set; }
        public int EventScheduleId { get; set; }
        public required EventScheduleEFModel EventSchedule { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
