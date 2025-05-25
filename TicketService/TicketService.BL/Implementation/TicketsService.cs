using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class TicketsService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IValidationService _validationService;

        public TicketsService(ITicketRepository ticketRepository, IValidationService validationService)
        {
            _ticketRepository = ticketRepository;
            _validationService = validationService;
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

        public async Task GenerateTicketAsync(int userId)
        {
            _ = await Task.FromResult(0);
        }
    }
}
