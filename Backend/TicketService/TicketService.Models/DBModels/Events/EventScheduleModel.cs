using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("EventSchedule")]
    public class EventScheduleModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
