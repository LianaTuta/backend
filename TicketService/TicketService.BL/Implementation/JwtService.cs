using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TicketService.BL.Interface;
using TicketService.Models.Configuration;

namespace TicketService.BL.Implementation
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettingsModel _jwtSettingsModel;
        public JwtService(IOptions<JwtSettingsModel> jwtSettingsModel)
        {
            _jwtSettingsModel = jwtSettingsModel.Value;
        }

        public string GenerateJwtToken(string email, string role)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettingsModel.SecretKey));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = [new Claim("email", email), new Claim("role", role)];
            JwtSecurityToken token = new(
                issuer: _jwtSettingsModel.ValidIssuer,
                audience: _jwtSettingsModel.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
