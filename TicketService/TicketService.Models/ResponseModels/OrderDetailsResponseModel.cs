namespace TicketService.Models.ResponseModels
{
    public class OrderDetailsResponseModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public required string EventName { get; set; }

        public required string TicketName { get; set; }

        public int EventId { get; set; }

        public string? TicketDownloadUrl { get; set; }

        public DateTime EventScheduleStartDate { get; set; }
        public DateTime EventScheduleEndDate { get; set; }

    }
}
