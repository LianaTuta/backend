using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IValidationService _validationService;

        public EventTypeService(IEventTypeRepository eventTypeRepository, IValidationService validationService)
        {
            _eventTypeRepository = eventTypeRepository;
            _validationService = validationService;
        }

        public async Task AddEventTypeAsync(AddNameRequestModel eventTypeRequestModel)
        {
            EventTypeModel eventSchedule = new()
            {
                Name = eventTypeRequestModel.Name,
                DateCreated = DateTime.UtcNow,
            };
            await _eventTypeRepository.InsertEventTypeAsync(eventSchedule);
        }

        public async Task EditEventTypeAsync(int id, AddNameRequestModel eventTypeRequestModel)
        {
            await _validationService.CheckEventTypeAsync(id);
            EventTypeModel eventType = await _eventTypeRepository.GetEventTypeByIdAsync(id);
            eventType.Name = eventTypeRequestModel.Name;
            eventType.DateUpdated = DateTime.UtcNow;
            await _eventTypeRepository.EditEventTypeAsync(eventType);
        }

        public async Task DeleteEventTypeAsync(int id)
        {
            await _validationService.CheckEventTypeAsync(id);
            await _eventTypeRepository.DeleteEventTypeByIdAsync(id);
        }

        public async Task<List<EventTypeModel>> GetEventTypesAsync()
        {
            return await _eventTypeRepository.GetEventTypesAsync();
        }
    }
}
