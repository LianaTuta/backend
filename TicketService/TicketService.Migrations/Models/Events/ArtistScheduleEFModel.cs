using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Events
{
    public class ArtistScheduleEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("artist_id")]
        public int ArtistId { get; set; }
        public required ArtistEFModel Artist { get; set; }

        [Column("event_schedule_id")]
        public int EventScheduleId { get; set; }
        public required EventScheduleEFModel EventSchedule { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

    }
}
