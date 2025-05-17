using System.Net;
using Microsoft.AspNetCore.Identity;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.User;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels;
using TicketService.Models.ResponseModels;

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

        public async Task CreateAccount(CreateUserRequestModel user)
        {
            await CheckIfUserExists(user.Email);

            string hashedPassowrd = HashPassword(user.Password);
            UserModel newUser = new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                MiddleName = user.LastName,
                LastName = user.LastName,
                DateCreated = DateTime.UtcNow,
                BirthDate = user.BirthDate,
                EmailConfirmed = false,
                Password = hashedPassowrd,
                RoleId = user.RoleId,

            };
            await _userAcccountRepository.InserUserAsync(newUser);
        }


        public async Task<BearerTokenModel> LoginAsync(LoginRequestModel login)
        {
            UserModel? userSaved = await _userAcccountRepository.GetUserByEmailAsync(login.Email);
            if (userSaved == null || VerifyPassword(userSaved.Password, login.Password) == false)
            {
                throw new CustomException("Invalid credentials", HttpStatusCode.BadRequest);
            }
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
            if (user != null)
            {
                throw new CustomException("An account with the same address already exists", HttpStatusCode.BadRequest);
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
