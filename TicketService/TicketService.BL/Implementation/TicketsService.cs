using System.Net;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.Payments;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class TicketsService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IValidationService _validationService;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        public TicketsService(ITicketRepository ticketRepository,
            IValidationService validationService,
            IOrderService orderService,
            IOrderRepository orderRepository,
            IPaymentRepository paymentRepository)
        {
            _ticketRepository = ticketRepository;
            _validationService = validationService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task AddTicketAsync(TicketRequestModel ticket)
        {
            await _validationService.CheckTicketCategoryAsync(ticket.TicketCategoryId);
            await _validationService.CheckEventScheduleAsync(ticket.EventScheduleId);
            TicketModel? ticketModel = new()
            {
                Description = ticket.Description,
                DateCreated = DateTime.UtcNow,
                Name = ticket.Name,
                DateUpdated = null,
                EventScheduleId = ticket.EventScheduleId,
                TicketCategoryId = ticket.TicketCategoryId,
                NumberOfAvailableTickets = ticket.NumberOfAvailableTickets,
                Price = ticket.Price,

            };
            _ = await _ticketRepository.InsertTicketAsync(ticketModel);

        }

        public async Task EditTicketAsync(int id, TicketRequestModel ticket)
        {
            await _validationService.CheckTicketAsync(id);
            await _validationService.CheckTicketCategoryAsync(ticket.TicketCategoryId);

            TicketModel currentTicket = await _ticketRepository.GetTicketByIdAsync(id);
            currentTicket.TicketCategoryId = ticket.TicketCategoryId;
            currentTicket.Description = ticket.Description;
            currentTicket.Name = ticket.Name;
            currentTicket.EventScheduleId = ticket.EventScheduleId;
            currentTicket.DateUpdated = DateTime.UtcNow;
            currentTicket.NumberOfAvailableTickets = ticket.NumberOfAvailableTickets;
            currentTicket.Price = ticket.Price;

            await _ticketRepository.EditTicketAsync(currentTicket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _validationService.CheckTicketAsync(id);
            await _ticketRepository.DeleteTicketAsync(id);
        }

        public async Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId)
        {

            return await _ticketRepository.GetTicketsByEventScheduleIdAsync(eventScheduleId);
        }

        public async Task<ValidateTicketResponseModel> GetTicketDataAsync(string code)
        {

            QrTicketModel ticket = await _ticketRepository.GetTicketByCodeAsync(code);
            if (ticket == null)
            {
                throw new CustomException("Ticket not found", HttpStatusCode.NotFound);
            }
            ValidateTicketResponseModel response = new()
            {
                TicketStatus = ticket.Status,
            };
            TicketOrderModel ticketOrder = await _orderRepository.GetTicketOrderByIdAsync(ticket.TicketOrderId);

            TicketModel? details = await _ticketRepository.GetTicketDetailsByIdAsync(ticketOrder.TicketId);
            TicketOrderPaymentModel ticketOrderPayment = await _paymentRepository.GetTicketOrderPaymentAsync(ticketOrder.Id);
            response.TicketDetails = new OrderDetailsResponseModel()
            {
                EventName = details.EventSchedule.EventModel.Name,
                TicketName = details.Name,
                Id = ticketOrder.Id,
                EventId = details.EventSchedule.EventId,
                EventScheduleEndDate = details.EventSchedule.EndDate,
                EventScheduleStartDate = details.EventSchedule.StartDate,
                Price = ticketOrderPayment == null ? 0 : ticketOrderPayment.Amount,
            };
            return response;
        }

        public async Task ValidateTicketAsync(ValidateTicketRequest validateTicketRequest)
        {
            QrTicketModel ticket = await _ticketRepository.GetTicketByCodeAsync(validateTicketRequest.Code);
            if (ticket == null)
            {
                throw new CustomException("Ticket not found", HttpStatusCode.NotFound);
            }
            ticket.DateUpdated = DateTime.UtcNow;
            ticket.Status = validateTicketRequest.Status;
            await _ticketRepository.UpdateQrCodeTicketAsync(ticket);
        }

    }



}

