namespace TicketService.Models.ResponseModels
{
    public class ValidateTicketResponseModel
    {
        public OrderDetailsResponseModel? TicketDetails { get; set; }
        public int TicketStatus { get; set; }
    }
}
