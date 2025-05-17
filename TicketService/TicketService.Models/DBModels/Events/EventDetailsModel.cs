using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("EventDetails")]
    public class EventDetailsModel
    {

        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public int EventId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
