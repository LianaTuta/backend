using System.Net;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.Exceptions;

namespace TicketService.BL.Implementation
{
    public class ValidationService : IValidationService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly ITicketRepository _ticketRepository;
        public ValidationService(IEventRepository eventRepository,
            IEventScheduleRepository eventScheduleRepository,
            IEventTypeRepository eventTypeRepository,
            ITicketCategoryRepository ticketCategoryRepository,
            ITicketRepository ticketRepository)
        {
            _eventRepository = eventRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _eventTypeRepository = eventTypeRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task CheckEventAsync(int id)
        {
            if (await _eventRepository.GetEventByIdAsync(id) == null)
            {
                throw new CustomException("No event with this id", HttpStatusCode.NotFound);
            }
        }
        public async Task CheckEventScheduleAsync(int id)
        {
            var aux = await _eventScheduleRepository.GetEventScheduleByIdAsync(id);
            if (await _eventScheduleRepository.GetEventScheduleByIdAsync(id) == null)
            {
                throw new CustomException("No event schedule with this id", HttpStatusCode.NotFound);
            }
        }

        public async Task CheckEventTypeAsync(int id)
        {
            if (await _eventTypeRepository.GetEventTypeByIdAsync(id) == null)
            {
                throw new CustomException("No event type with this id", HttpStatusCode.NotFound);
            }
        }

        public async Task CheckTicketCategoryAsync(int id)
        {
            if (await _ticketCategoryRepository.GetTicketCategoryByIdAsync(id) == null)
            {
                throw new CustomException("No ticket category with this id", HttpStatusCode.NotFound);
            }
        }

        public async Task CheckTicketAsync(int id)
        {
            if (await _ticketRepository.GetTicketByIdAsync(id) == null)
            {
                throw new CustomException("No ticket with this id", HttpStatusCode.NotFound);
            }
        }

    }
}
