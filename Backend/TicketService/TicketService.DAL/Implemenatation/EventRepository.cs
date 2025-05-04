using System.Data;
using Dapper;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels;

namespace TicketService.DAL.Implemenatation
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _dbConnection;

        public EventRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> InserEventAsync(EventModel eventModel)
        {
            int id = await _dbConnection.InsertAsync<EventModel, int>(eventModel);
            return id;
        }

        public async Task EditEventAsync(EventModel eventModel)
        {
            _ = await _dbConnection.UpdateAsync(eventModel);
        }

        public async Task DeleteEventAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<EventModel>(id);
        }

        public async Task<List<EventModel>> GetEventsAsync()
        {
            /* var result = connection
                .Query<User>()
                .Join(connection.Query<Role>(), 
                      u => u.Id, 
                      ur => ur.Id, 
                      (u, r) => new { u, r })
                .Join(connection.Query<UserRole>(), 
                      ur => ur.u.Id, 
                      ur => ur.UserId, 
                      (ur, ur2) => new { ur.u, ur.r, ur2 })
                .Select(x => new UserRoleJoinResult
                {
                    UserId = x.u.Id,
                    UserName = x.u.Name,
                    RoleName = x.r.RoleName
                })
                .ToList();*/
            return (await _dbConnection.QueryAllAsync<EventModel>()).ToList();
        }
        public async Task<EventModel?> GetEventByIdAsync(int id)
        {

            return (await _dbConnection.QueryAsync<EventModel>(u => u.Id == id)).FirstOrDefault();
        }


        public async Task InserEventDetailsAsync(EventDetailsModel eventDetails)
        {
            _ = await _dbConnection.InsertAsync(eventDetails);
        }

        public async Task<EventDetailsModel?> GetEventDetailsByEventIdAsync(int eventId)
        {

            return (await _dbConnection.QueryAsync<EventDetailsModel>(u => u.EventId == eventId)).FirstOrDefault();
        }


    }
}
