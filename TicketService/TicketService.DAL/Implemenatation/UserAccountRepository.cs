
using Dapper;
using RepoDb;
using System.Data;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.User;

namespace TicketService.DAL.Implemenatation
{
    public class UserAccountRepository : IUserAcccountRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserAccountRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task InserUserAsync(UserModel userModel)
        {
            _ = await _dbConnection.InsertAsync(userModel);
        }

        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            return (await _dbConnection.QueryAsync<UserModel>(u => u.Email == email))?.FirstOrDefault();

        }

        public async Task<UserRolesModel> GetUserRolesById(int id)
        {
            return (await _dbConnection.QueryAsync<UserRolesModel>(u => u.Id == id)).FirstOrDefault();
        }
    }
}
