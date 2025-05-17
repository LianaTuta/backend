using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class EventDetailsService : IEventDetailsService
    {
        private readonly IEventDetailsRepository _eventDetailsRepository;
        private readonly IValidationService _validationService;
        public EventDetailsService(IEventDetailsRepository eventDetailsRepository, IValidationService validationService)
        {
            _eventDetailsRepository = eventDetailsRepository;
            _validationService = validationService;
        }
        public async Task AddEventDetailsAsync(EventDetailsRequest addEventDetailsRequest)
        {
            await _validationService.CheckEventAsync(addEventDetailsRequest.EventId);
            EventDetailsModel eventDetails = new()
            {
                EventId = addEventDetailsRequest.EventId,
                Description = addEventDetailsRequest.Description,
                Location = addEventDetailsRequest.Location,
                DateCreated = DateTime.UtcNow,
            };
            await _eventDetailsRepository.InsertEventDetailsAsync(eventDetails);
        }

        public async Task<EventDetailsModel> GetEventDetailAsync(int id)
        {
            return await _eventDetailsRepository.GetEventDetailsByEventIdAsync(id);
        }
    }
}
