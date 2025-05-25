using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Events
{
    public class EventScheduleEFModel
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("event_id")]
        public int EventId { get; set; }
        public required EventEFModel Event { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("location")]
        public required string Location { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }

    }
}
