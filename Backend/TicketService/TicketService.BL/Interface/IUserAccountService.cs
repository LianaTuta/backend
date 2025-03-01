using TicketService.Models;

namespace TicketService.BL.Interface
{
    public interface IUserAccountService
    {
        public Task CreateAccount(UserModel user);
        public Task<string> LoginAsync(LoginModel login);
    }
}
