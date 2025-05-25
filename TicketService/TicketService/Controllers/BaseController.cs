using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.User;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IUserAcccountRepository _userAcccountRepository;
        public BaseController(IUserAcccountRepository userAcccountRepository)
        {
            _userAcccountRepository = userAcccountRepository;
        }
        protected async Task<int> GetUserIdAsync()
        {
            string? userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail == null)
            {
                return 0;
            }
            UserModel? user = await _userAcccountRepository.GetUserByEmailAsync(userEmail.ToString());
            return user.Id;
        }
    }
}
