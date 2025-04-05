using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels
{
    [Table("EventType")]
    public class EventTypeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
