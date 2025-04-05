using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels
{
    [Table("EventDetails")]
    public class EventDetailsModel
    {

        public int Id { get; set; }
        public int TotalNumberSeats { get; set; }

        public int EventId { get; set; }
    }
}
