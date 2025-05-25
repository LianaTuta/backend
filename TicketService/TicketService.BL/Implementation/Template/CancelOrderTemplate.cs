using TicketService.BL.Interface;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation.Template
{
    public class CancelOrderTemplate : BaseOrderTemplate
    {
        private readonly IOrderService _orderService;
        private readonly ITicketService _ticketService;
        public CancelOrderTemplate(ITicketService ticketService, IOrderService orderService)
        {
            _ticketService = ticketService;
            _orderService = orderService;


        }


        protected override Task<OrderResponseModel> HandlePaymentAsync(int userId, int checkoutOrderId)
        {
            throw new NotImplementedException();
        }

        protected override Task HandleOrderAsync(int userId, int userOrderCheckoutId)
        {
            throw new NotImplementedException();
        }

        protected override Task HandleTicketAsync(int userId, int checkoutOrderId)
        {
            throw new NotImplementedException();
        }
    }
}
