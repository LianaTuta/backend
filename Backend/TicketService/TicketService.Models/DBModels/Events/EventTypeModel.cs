using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("EventType")]
    public class EventTypeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
