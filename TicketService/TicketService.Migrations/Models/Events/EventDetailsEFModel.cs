using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Events
{
    public class EventDetailsEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public required string Description { get; set; }

        [Column("location")]
        public required string Location { get; set; }

        [Column("event_id")]
        public int EventId { get; set; }
        public required EventEFModel Event { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
