namespace TicketService.Migrations.Models.Events
{
    public class ArtistScheduleEFModel
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public required ArtistEFModel Artist { get; set; }
        public int EventScheduleId { get; set; }
        public required EventScheduleEFModel EventSchedule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
