using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.RequestModels;
using TicketService.Models.ResponseModels;

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
        public async Task CreateAccount(CreateUserRequestModel userModel)
        {
            await _userAccountService.CreateAccount(userModel);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<BearerTokenModel> LoginAsync(LoginModel loginDetails)
        {

            return await _userAccountService.LoginAsync(loginDetails);
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
