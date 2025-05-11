using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class EventScheduleService : IEventScheduleService
    {
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly IValidationService _validationService;
        public EventScheduleService(IEventScheduleRepository eventScheduleRepository,
            IValidationService validationService)
        {
            _eventScheduleRepository = eventScheduleRepository;
            _validationService = validationService;
        }
        public async Task AddEventScheduleAsync(EventScheduleRequest addEventScheduleRequest)
        {
            await _validationService.CheckEventAsync(addEventScheduleRequest.EventId);
            EventScheduleModel eventSchedule = new()
            {
                EventId = addEventScheduleRequest.EventId,
                StartDate = addEventScheduleRequest.StartDate,
                EndDate = addEventScheduleRequest.EndDate,
                Location = addEventScheduleRequest.Location,
                Name = addEventScheduleRequest.Name,
                DateCreated = DateTime.UtcNow,
                DateUpdated = null,
            };
            await _eventScheduleRepository.InsertEventScheduleAsync(eventSchedule);
        }

        public async Task EditEventScheduleAsync(int id, EventScheduleRequest eventScheduleRequest)
        {
            await _validationService.CheckEventAsync(eventScheduleRequest.EventId);
            await _validationService.CheckEventScheduleAsync(id);
            EventScheduleModel currentEventSchedule = await _eventScheduleRepository.GetEventScheduleByIdAsync(id);
            currentEventSchedule.Location = eventScheduleRequest.Location;
            currentEventSchedule.StartDate = eventScheduleRequest.StartDate;
            currentEventSchedule.EndDate = eventScheduleRequest.EndDate;
            currentEventSchedule.Name = eventScheduleRequest.Name;
            currentEventSchedule.DateUpdated = DateTime.UtcNow;
            await _eventScheduleRepository.InsertEventScheduleAsync(currentEventSchedule);
        }

        public async Task DeleteEventScheduleAsync(int id)
        {
            await _eventScheduleRepository.DeleteEventScheduleByIdAsync(id);
        }

        public async Task<List<EventScheduleModel>> GetEventSchedulesByEventIdAsync(int eventId)
        {
            return await _eventScheduleRepository.GetEventSchedulesByEventIdAsync(eventId);
        }
    }
}
