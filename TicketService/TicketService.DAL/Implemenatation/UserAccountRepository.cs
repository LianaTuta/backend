using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.User;

namespace TicketService.DAL.Implemenatation
{
    public class UserAccountRepository : BaseRepository, IUserAcccountRepository
    {
        public UserAccountRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task InserUserAsync(UserModel userModel)
        {
            await _dbConnection.InsertAsync(userModel);
        }

        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            return (await _dbConnection.FindAsync<UserModel>(statement =>
        statement
            .Where($"{nameof(UserModel.Email):C} = @Email")
            .WithParameters(new { Email = email }))).ToList().FirstOrDefault();

        }

        public async Task<UserRolesModel> GetUserRolesById(int id)
        {
            return (await _dbConnection.FindAsync<UserRolesModel>(statement =>
                            statement
                        .Where($"{nameof(UserRolesModel.Id):C} = @Id")
                        .WithParameters(new { Id = id }))).ToList().FirstOrDefault();
        }
    }
}
