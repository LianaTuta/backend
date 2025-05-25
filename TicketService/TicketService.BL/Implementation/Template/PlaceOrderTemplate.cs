using TicketService.BL.Interface;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation.Template
{
    public class PlaceOrderTemplate : BaseOrderTemplate
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ITicketService _ticketService;
        public PlaceOrderTemplate(ITicketService ticketService,
            IOrderService orderService,
            IPaymentService paymentService)
        {
            _ticketService = ticketService;
            _orderService = orderService;
            _paymentService = paymentService;

        }


        protected override async Task<OrderResponseModel> HandlePaymentAsync(int userId, int checkoutOrderId)
        {
            return await _paymentService.CreatePaymentAsync(userId, checkoutOrderId);
        }

        protected override async Task HandleOrderAsync(int userId, int checkoutOrderId)
        {
            await _orderService.UpdateUserOrderAsync(checkoutOrderId);
        }

        protected override Task HandleTicketAsync(int userId, int checkoutOrderId)
        {
            throw new NotImplementedException();
        }
    }
}
