using TicketService.Models.DBModels.User;

namespace TicketService.DAL.Interface
{
    public interface IUserAcccountRepository
    {
        Task InserUserAsync(UserModel userModel);
        Task<UserModel?> GetUserByEmailAsync(string email);
        Task<UserRolesModel> GetUserRolesById(int id);
        Task<UserModel?> GetUserByIdAsync(int id);

    }
}
