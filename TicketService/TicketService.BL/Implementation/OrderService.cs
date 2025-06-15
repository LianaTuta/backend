using System.Text.Json;
using TicketService.ApiClient.Interface;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.Payments;
using TicketService.Models.Enum;
using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IGoogleClient _googleClient;
        public OrderService(IOrderRepository orderRepository,
            IPaymentRepository paymentRepository,
            ITicketRepository ticketRepository,
            IGoogleClient googleClient)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _ticketRepository = ticketRepository;
            _googleClient = googleClient;
        }

        public Task CheckProductAvailability(CheckoutOrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CheckoutOrderDetailsResponseModel>?> GetOrdersAsync(int userId)
        {
            List<CheckoutOrderModel> checkoutOrders = (await _orderRepository.GetOrdersByUserIdAsync(userId)).OrderBy(o => o.Id).ToList();
            List<CheckoutOrderDetailsResponseModel> checkoutOrderDetails = [];

            foreach (CheckoutOrderModel order in checkoutOrders)
            {
                List<OrderDetailsResponseModel> tickerOrderDetails = [];
                List<TicketOrderModel> ticketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(order.Id);
                PaymentModel payment = await _paymentRepository.GetPaymentByCheckoutOrderIdAsync(order.Id);
                foreach (TicketOrderModel ticketOrder in ticketOrders)
                {
                    TicketModel? details = await _ticketRepository.GetTicketDetailsByIdAsync(ticketOrder.TicketId);
                    TicketOrderPaymentModel ticketOrderPayment = await _paymentRepository.GetTicketOrderPaymentAsync(ticketOrder.Id);

                    tickerOrderDetails.Add(new OrderDetailsResponseModel()
                    {
                        EventName = details.EventSchedule.EventModel.Name,
                        TicketName = details.Name,
                        Id = ticketOrder.Id,
                        EventId = details.EventSchedule.EventId,
                        EventScheduleEndDate = details.EventSchedule.EndDate,
                        EventScheduleStartDate = details.EventSchedule.StartDate,
                        Price = ticketOrderPayment == null ? 0 : ticketOrderPayment.Amount,
                    });

                }

                checkoutOrderDetails.Add(new CheckoutOrderDetailsResponseModel()
                {
                    Details = tickerOrderDetails,
                    Step = order.Step,
                    TotalPrice = (double)payment.Amount,
                    Id = order.Id,
                    PaymentUrl = payment.Status == (int)PaymentStatusEnum.InProgress ? payment.ReturnUrl : null,
                    DateCreated = order.DateCreated,
                });
            }
            return checkoutOrderDetails;
        }

        public async Task<CheckoutOrderDetailsResponseModel?> GetChekoutOrderDetailsAsync(int userId, int checkoutOrderId)
        {
            //cehck bearer validity
            CheckoutOrderModel checkoutOrder = await _orderRepository.GetOrdersByCheckoutOrderIdAsync(checkoutOrderId);
            List<OrderDetailsResponseModel> tickerOrderDetails = [];
            List<TicketOrderModel> ticketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrder.Id);
            PaymentModel payment = await _paymentRepository.GetPaymentByCheckoutOrderIdAsync(checkoutOrder.Id);
            foreach (TicketOrderModel ticketOrder in ticketOrders)
            {
                TicketModel? details = await _ticketRepository.GetTicketDetailsByIdAsync(ticketOrder.TicketId);
                TicketOrderPaymentModel ticketOrderPayment = await _paymentRepository.GetTicketOrderPaymentAsync(ticketOrder.Id);
                string? ticketDownloadUrl = null;
                if (checkoutOrder.Step == (int)OrderStep.Completed)
                {
                    List<string> file = await _googleClient.GetFilesAsync($"order/{ticketOrder.Id}/");
                    ticketDownloadUrl = file.Any() ? _googleClient.GenerateSignedUrl(file.FirstOrDefault()) : null;
                }
                tickerOrderDetails.Add(new OrderDetailsResponseModel()
                {
                    EventName = details.EventSchedule.EventModel.Name,
                    TicketName = details.Name,
                    Id = ticketOrder.Id,
                    EventId = details.EventSchedule.EventId,
                    EventScheduleEndDate = details.EventSchedule.EndDate,
                    EventScheduleStartDate = details.EventSchedule.StartDate,
                    Price = ticketOrderPayment == null ? 0 : ticketOrderPayment.Amount,
                    TicketDownloadUrl = ticketDownloadUrl,
                });
            }
            CheckoutOrderDetailsResponseModel checkoutOrderDetailsResponseModel = new()
            {
                Details = tickerOrderDetails,
                Step = checkoutOrder.Step,
                TotalPrice = (double)payment.Amount,
                Id = checkoutOrder.Id,
                PaymentUrl = payment.Status == (int)PaymentStatusEnum.InProgress ? payment.ReturnUrl : null,
                DateCreated = checkoutOrder.DateCreated,
            };
            return checkoutOrderDetailsResponseModel;
        }

        public async Task<int> InsertDefaultOrdersAsync(int userId, CheckoutRequest checkoutRequest)
        {
            int checkoutOrderId = await SaveCheckoutOrderAsync(userId, checkoutRequest);
            foreach (OrderTicketsModel ticketOrder in checkoutRequest.OrderTickets)
            {
                TicketOrderModel ticket = new()
                {
                    TicketId = ticketOrder.Id,
                    StartDate = DateTime.UtcNow,
                    CheckoutOrderId = checkoutOrderId,
                };
                await _orderRepository.InsertTicketOrderAsync(ticket);
            }
            return checkoutOrderId;
        }

        public async Task UpdateUserOrderAsync(int checkoutOrderId, int orderStep)
        {
            await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, orderStep);
        }

        public async Task CancelCheckoutOrderAsync(int checkoutOrderId)
        {

            CheckoutOrderModel checkoutOrder = await _orderRepository.GetOrdersByCheckoutOrderIdAsync(checkoutOrderId);
            if (checkoutOrder != null)
            {
                if (checkoutOrder.DateCreated < DateTime.UtcNow.AddMinutes(-30))
                {
                    await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Expired);
                }
                else
                {
                    await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Cancelled);
                }
            }
            List<TicketOrderModel> ticketOrders = await _orderRepository.GetTicketOrderByCheckoutOrderIdAsync(checkoutOrderId);
            foreach (TicketOrderModel ticketOrder in ticketOrders)
            {
                ticketOrder.EndDate = DateTime.UtcNow;
                await _orderRepository.UpdateTicketOrderAsync(ticketOrder);
            }

        }

        public Task<List<CheckoutOrderModel>> GetExpiredOrderAsync()
        {
            return _orderRepository.GetExpiredOrdersAsync();
        }

        #region private 

        private async Task<int> SaveCheckoutOrderAsync(int userId, CheckoutRequest orderModel)
        {


            CheckoutOrderModel order = new()
            {
                UserId = userId,
                Step = (int)OrderStep.Initial,
                DateCreated = DateTime.UtcNow,
                Order = JsonSerializer.Serialize(orderModel),
            };
            return await _orderRepository.InserCheckoutOrderAsync(order);
        }



        #endregion
    }
}

