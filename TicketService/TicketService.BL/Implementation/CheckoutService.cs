using TicketService.BL.Implementation.Template;
using TicketService.BL.Interface;
using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class CheckoutService : ICheckoutService
    {
        private readonly PlaceOrderTemplate _placeOrderTemplate;
        private readonly CancelOrderTemplate _cancelOrderTemplate;
        private readonly IOrderService _orderService;

        public CheckoutService(PlaceOrderTemplate placeOrderTemplate,
            CancelOrderTemplate cancelOrderTemplate,
            IOrderService orderService)
        {

            _placeOrderTemplate = placeOrderTemplate;
            _cancelOrderTemplate = cancelOrderTemplate;
            _orderService = orderService;
        }

        public async Task CancelOrderAsync(int userId, int checkoutOrderId)
        {

            _ = await _cancelOrderTemplate.ProcessOrder(userId, checkoutOrderId);
        }

        public Task CancelOrderAsync(int userId, CheckoutRequest checkout)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponseModel> ProcessOrderAsync(int userId, CheckoutRequest checkout)
        {
            int checkoutOrderId = checkout.CheckoutOrderId.HasValue ? checkout.CheckoutOrderId.Value : 0;
            if (checkout.CheckoutOrderId == null)
            {
                checkoutOrderId = await _orderService.InsertDefaultOrdersAsync(userId, checkout);
            }
            return await _placeOrderTemplate.ProcessOrder(userId, checkoutOrderId);

        }
    }
}
