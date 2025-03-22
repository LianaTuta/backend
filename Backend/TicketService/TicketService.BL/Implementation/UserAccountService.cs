using Microsoft.AspNetCore.Identity;
using System.Net;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models;
using TicketService.Models.Exceptions;

namespace TicketService.BL.Implementation
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAcccountRepository _userAcccountRepository;
        private readonly IJwtService _jwtService;
        private readonly PasswordHasher<object> _passwordHasher = new();

        public UserAccountService(IUserAcccountRepository userAcccountRepository, IJwtService jwtService)
        {
            _userAcccountRepository = userAcccountRepository;
            _jwtService = jwtService;
        }

        public async Task CreateAccount(UserModel user)
        {
            await CheckIfUserExists(user.Email);
            string hashedPassowrd = HashPassword(user.Password);
            user.Password = hashedPassowrd;
            await _userAcccountRepository.InserUserAsync(user);
        }

        public async Task<BearerTokenModel> LoginAsync(LoginModel login)
        {
            UserModel? userSaved = await _userAcccountRepository.GetUserByEmailAsync(login.Email);
            //!!!!! check for this if 
            _ = VerifyPassword(userSaved.Password, login.Password);
            UserRolesModel? role = await _userAcccountRepository.GetUserRolesById((int)userSaved.RoleId);
            return new BearerTokenModel()
            {
                Token = _jwtService.GenerateJwtToken(userSaved.Id, role.Name)
            };
        }

        #region private methods

        private async Task CheckIfUserExists(string email)
        {
            UserModel? user = await _userAcccountRepository.GetUserByEmailAsync(email);
            //!!!!! exceptions need to be changed ugly
            if (user != null)
            {
                throw new CustomException( "An account with the same address already exists", HttpStatusCode.BadRequest);
            }
        }

        private string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
        #endregion  

    }
}
