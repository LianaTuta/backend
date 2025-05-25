namespace TicketService.Models.RequestModels.Order
{
    public class CheckoutRequest
    {
        public required List<OrderTicketsModel> OrderTickets { get; set; }
        public int? CheckoutOrderId { get; set; }
    }
}
