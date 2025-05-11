using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("Event")]
    public class EventModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int EventTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
