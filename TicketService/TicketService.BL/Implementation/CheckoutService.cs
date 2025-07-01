using System.Net;
using TicketService.BL.Implementation.Template;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class CheckoutService : ICheckoutService
    {
        private readonly PlaceOrderTemplate _placeOrderTemplate;
        private readonly CancelOrderTemplate _cancelOrderTemplate;
        private readonly IOrderService _orderService;
        private readonly ITicketRepository _ticketRepository;

        public CheckoutService(PlaceOrderTemplate placeOrderTemplate,
            CancelOrderTemplate cancelOrderTemplate,
            IOrderService orderService,
            ITicketRepository ticketRepository)
        {

            _placeOrderTemplate = placeOrderTemplate;
            _cancelOrderTemplate = cancelOrderTemplate;
            _orderService = orderService;
            _ticketRepository = ticketRepository;
        }

        public async Task CancelOrderAsync(int userId, int checkoutOrderId)
        {

            _ = await _cancelOrderTemplate.ProcessOrder(userId, checkoutOrderId);
        }

        public async Task CancelExpiredOrdersAsync()
        {
            List<CheckoutOrderModel> expiredOrders = await _orderService.GetExpiredOrderAsync();
            foreach (CheckoutOrderModel order in expiredOrders)
            {
                _ = await _cancelOrderTemplate.ProcessOrder(order.UserId, order.Id);
            }
        }

        public async Task<ValidTicketModel> IsValidTicket(int ticketId)
        {

            return await _orderService.GetTicketValidity(ticketId);
        }


        public async Task<OrderResponseModel> ProcessOrderAsync(int userId, CheckoutRequest checkout)
        {
            int checkoutOrderId = checkout.CheckoutOrderId.HasValue ? checkout.CheckoutOrderId.Value : 0;
            foreach (OrderTicketsModel ticket in checkout.OrderTickets)
            {
                ValidTicketModel validity = await _orderService.GetTicketValidity(ticket.Id);
                if (validity == null)
                {
                    throw new CustomException("Ticket not valid", HttpStatusCode.NotFound);
                }
                if (validity.IsValid == false)
                {
                    throw new CustomException("Ticket not available", HttpStatusCode.BadRequest);
                }
            }
            if (checkout.CheckoutOrderId == null)
            {
                checkoutOrderId = await _orderService.InsertDefaultOrdersAsync(userId, checkout);
            }
            return await _placeOrderTemplate.ProcessOrder(userId, checkoutOrderId);

        }

    }
}
