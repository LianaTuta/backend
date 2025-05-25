using TicketService.BL.Interface;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation.Template
{
    public class PlaceOrderTemplate : BaseOrderTemplate
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IQRTicketService _qRTicketService;
        public PlaceOrderTemplate(ITicketService ticketService,
            IOrderService orderService,
            IPaymentService paymentService,
            IQRTicketService qRTicketService)
        {
            _qRTicketService = qRTicketService;
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

        protected override async Task HandleTicketAsync(int userId, int checkoutOrderId)
        {
            await _qRTicketService.GenerateTicketAsync(userId, checkoutOrderId);
        }
    }
}
