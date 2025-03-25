using TicketService.Models.RequestModels;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface IUserAccountService
    {
        Task CreateAccount(CreateUserRequestModel user);
        Task<BearerTokenModel> LoginAsync(LoginModel login);
    }
}
