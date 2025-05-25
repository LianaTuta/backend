namespace TicketService.Models.QR
{
    public class TicketQRModel
    {
        public required string Email { get; set; }
        public required string EventName { get; set; }
        public DateTime EventScheduleStartDate { get; set; }
        public DateTime EventScheduleEndDate { get; set; }
        public double Price { get; set; }

        public required string TicketCategory { get; set; }
    }
}
