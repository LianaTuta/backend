namespace TicketService.Models.ResponseModels
{
    public class CheckoutOrderDetailsResponseModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public required int Step { get; set; }
        public string? PaymentUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public required List<OrderDetailsResponseModel> Details { get; set; }
    }
}
