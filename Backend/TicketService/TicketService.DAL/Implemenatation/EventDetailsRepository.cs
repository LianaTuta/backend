using System.Data;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventDetailsRepository : IEventDetailsRepository
    {
        private readonly IDbConnection _dbConnection;

        public EventDetailsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task InsertEventDetailsAsync(EventDetailsModel eventDetails)
        {
            _ = await _dbConnection.InsertAsync(eventDetails);
        }

        public async Task<EventDetailsModel?> GetEventDetailsByEventIdAsync(int eventId)
        {

            return (await _dbConnection.QueryAsync<EventDetailsModel>(u => u.EventId == eventId)).FirstOrDefault();
        }
    }
}
