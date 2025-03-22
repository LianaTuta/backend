using TicketService.Models;

namespace TicketService.BL.Interface
{
    public interface IUserAccountService
    {
        public Task CreateAccount(UserModel user);
        public Task<BearerTokenModel> LoginAsync(LoginModel login);
    }
}
