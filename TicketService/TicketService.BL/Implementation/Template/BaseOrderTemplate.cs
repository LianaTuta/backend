using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation.Template
{
    public abstract class BaseOrderTemplate
    {
        public async Task<OrderResponseModel?> ProcessOrder(int userId, int checkoutOrderId)
        {
            OrderResponseModel payment = await HandlePaymentAsync(userId, checkoutOrderId);
            if (payment != null)
            {
                return payment;
            }
            await HandleOrderAsync(userId, checkoutOrderId);
            await HandleTicketAsync(userId, checkoutOrderId);
            return null;
        }

        protected abstract Task<OrderResponseModel> HandlePaymentAsync(int userId, int checkoutOrderId);
        protected abstract Task HandleOrderAsync(int userId, int userOrderCheckoutId);
        protected abstract Task HandleTicketAsync(int userId, int checkoutOrderId);
    }
}
