using TicketService.BL.Interface;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation.Template
{
    public class CancelOrderTemplate : BaseOrderTemplate
    {
        private readonly IOrderService _orderService;
        private readonly IQRTicketService _qRTicketService;
        private readonly IPaymentService _paymentService;
        public CancelOrderTemplate(IQRTicketService qRTicketService,
            IOrderService orderService,
            IPaymentService paymentService)
        {
            _qRTicketService = qRTicketService;
            _orderService = orderService;
            _paymentService = paymentService;


        }

        protected override async Task<OrderResponseModel>? HandlePaymentAsync(int userId, int checkoutOrderId)
        {
            _ = await _paymentService.CreateRefundPaymentAsync(userId, checkoutOrderId);
            return null;
        }

        protected override async Task HandleOrderAsync(int userId, int userOrderCheckoutId)
        {
            await _orderService.CancelCheckoutOrderAsync(userOrderCheckoutId);
        }

        protected override async Task HandleTicketAsync(int userId, int checkoutOrderId)
        {
            await _qRTicketService.UpdateTicketAsync(userId, checkoutOrderId);
        }
    }
}
