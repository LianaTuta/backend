using System.Net;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
            await _eventRepository.InserEventAsync(eventModel);
        }

        public async Task<List<EventModel>> GetEventListAsync()
        {
            return await _eventRepository.GetEventsAsync();
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
        #endregion

    }
}
