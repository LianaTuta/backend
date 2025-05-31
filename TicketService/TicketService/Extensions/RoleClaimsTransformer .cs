using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.User;

public class SecureRoleClaimsTransformer : IClaimsTransformation
{
    private readonly IUserAcccountRepository _userService;

    public SecureRoleClaimsTransformer(IUserAcccountRepository userService)
    {
        _userService = userService;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity? identity = (ClaimsIdentity)principal.Identity;

        if (identity == null || !identity.IsAuthenticated)
        {
            return principal;
        }

        List<Claim> roleClaims = identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
        foreach (Claim? rc in roleClaims)
        {
            identity.RemoveClaim(rc);
        }

        string? email = principal.FindFirst(ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            return principal;
        }

        UserModel? user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return principal;
        }

        UserRolesModel role = await _userService.GetUserRolesById((int)user.RoleId);
        identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));

        return principal;
    }
}
