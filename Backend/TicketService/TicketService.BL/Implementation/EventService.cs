using TicketService.ApiClient.Interface;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IGoogleClient _googleClient;
        private readonly IValidationService _validationService;

        public EventService(IEventRepository eventRepository,
            IGoogleClient googleClient,
            IValidationService validationService)
        {
            _eventRepository = eventRepository;
            _googleClient = googleClient;
            _validationService = validationService;
        }

        public async Task AddEventAsync(EventRequest addEventRequest)
        {
            await _validationService.CheckEventTypeAsync(addEventRequest.EventTypeId);
            EventModel eventModel = new()
            {
                Name = addEventRequest.Name,
                Description = addEventRequest.Description,
                EventTypeId = addEventRequest.EventTypeId,
                DateCreated = DateTime.UtcNow,
            };
            int id = await _eventRepository.InsertEventAsync(eventModel);
            await _googleClient.UploadFileAsync(addEventRequest.Photo, $"event/{id}");
        }

        public async Task<List<EventsResponseModel>> GetEventListAsync()
        {
            List<EventModel> events = await _eventRepository.GetEventsAsync();
            List<EventsResponseModel> eventResponse = [];
            foreach (EventModel eventModel in events)
            {
                List<string> path = await _googleClient.GetFilesAsync($"event/{eventModel.Id}/");
                string? imageUrl = path.Any() ? _googleClient.GenerateSignedUrl(path.FirstOrDefault()) : null;
                eventResponse.Add(new EventsResponseModel()
                {
                    Id = eventModel.Id,
                    Description = eventModel.Description,
                    Name = eventModel.Name,
                    EventTypeId = eventModel.EventTypeId,
                    ImagePath = imageUrl,
                    Created = eventModel.DateCreated,
                    LastUpdated = eventModel.DateUpdated.Value,
                }
                );
            }
            return eventResponse;
        }

        public async Task EditEventAsync(int id, EventRequest editEventRequest)
        {
            await _validationService.CheckEventAsync(id);
            await _validationService.CheckEventTypeAsync(id);
            EventModel? eventModel = await _eventRepository.GetEventByIdAsync(id);
            eventModel.Name = editEventRequest.Name;
            eventModel.DateUpdated = DateTime.UtcNow;
            eventModel.Description = editEventRequest.Description;
            eventModel.EventTypeId = editEventRequest.EventTypeId;
            await _eventRepository.EditEventAsync(eventModel);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _validationService.CheckEventAsync(id);
            await _eventRepository.DeleteEventAsync(id);
        }
    }
}