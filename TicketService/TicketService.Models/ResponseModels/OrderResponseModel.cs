using TicketService.Models.Enum;

namespace TicketService.Models.ResponseModels
{
    public class OrderResponseModel
    {
        public int CheckoutOrderId { get; set; }
        public OrderStep Step { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
