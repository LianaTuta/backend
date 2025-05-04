using System.Net;
using TicketService.ApiClient.Interface;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IGoogleClient _googleClient;

        public EventService(IEventRepository eventRepository, IGoogleClient googleClient)
        {
            _eventRepository = eventRepository;
            _googleClient = googleClient;
        }

        public async Task AddEventAsync(AddEventRequest addEventRequest)
        {
            EventModel eventModel = new()
            {
                Name = addEventRequest.Name,
                Description = addEventRequest.Description,
                EventTypeId = addEventRequest.EventTypeId,
                Created = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
            };
            int id = await _eventRepository.InserEventAsync(eventModel);
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
                    Created = eventModel.Created,
                    LastUpdated = eventModel.LastUpdated
                }
                );
            }
            return eventResponse;
        }
        public async Task EditEventAsync(int id, AddEventRequest addEventRequest)
        {
            await CheckEventAsync(id);
            EventModel? eventModel = await _eventRepository.GetEventByIdAsync(id);
            EventModel updatedEvent = new()
            {
                Id = id,
                Name = addEventRequest.Name,
                Description = addEventRequest.Description,
                EventTypeId = addEventRequest.EventTypeId,
                Created = eventModel.Created,
                LastUpdated = DateTime.UtcNow,
            };
            await _eventRepository.EditEventAsync(updatedEvent);
        }

        public async Task DeleteAsync(int id)
        {
            await CheckEventAsync(id);
            await _eventRepository.DeleteEventAsync(id);
        }

        #region private
        private async Task CheckEventAsync(int id)
        {
            if (await _eventRepository.GetEventByIdAsync(id) == null)
            {
                throw new CustomException("No event with this id", HttpStatusCode.NotFound);
            }
        }

        public Task AddEventDetailsAsync(int id, AddEventDetailsRequest addEventDetailsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<EventDetailsModel> GetEventDetailAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}