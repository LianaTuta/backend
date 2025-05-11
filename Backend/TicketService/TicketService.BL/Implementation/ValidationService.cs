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
        public ValidationService(IEventRepository eventRepository,
            IEventScheduleRepository eventScheduleRepository,
            IEventTypeRepository eventTypeRepository)
        {
            _eventRepository = eventRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _eventTypeRepository = eventTypeRepository;
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
            if (await _eventScheduleRepository.GetEventSchedulesByEventIdAsync(id) == null)
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
    }
}
