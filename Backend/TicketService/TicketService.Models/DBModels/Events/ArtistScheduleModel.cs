namespace TicketService.Models.DBModels.Events
{
    public class ArtistScheduleModel
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
