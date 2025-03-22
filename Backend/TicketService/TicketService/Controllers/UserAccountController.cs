using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("create-account")]
        [AllowAnonymous]
        public async Task CreateAccount(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }
            await _userAccountService.CreateAccount(userModel);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<BearerTokenModel> Login(LoginModel loginDetails)
        {
            return loginDetails == null
                ? throw new ArgumentNullException(nameof(loginDetails))
                : await _userAccountService.LoginAsync(loginDetails);
        }

        [HttpGet("test")]
        [AllowAnonymous]
        public string TestAuth()
        {
            return "Test";
        }

        [HttpGet("test-m")]
        [Authorize(Roles = "Manager")]
        public string TestManger()
        {
            return "Test Manger";
        }

        [HttpGet("test-c")]
        [Authorize(Roles = "Customer")]
        public string TestCustomer()
        {
            return "Test C";
        }
    }
}
