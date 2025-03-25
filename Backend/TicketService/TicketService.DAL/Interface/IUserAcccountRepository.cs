using TicketService.Models.DBModels;

namespace TicketService.DAL.Interface
{
    public interface IUserAcccountRepository
    {
        Task InserUserAsync(UserModel userModel);
        Task<UserModel?> GetUserByEmailAsync(string email);
        Task<UserRolesModel> GetUserRolesById(int id);
    }
}
