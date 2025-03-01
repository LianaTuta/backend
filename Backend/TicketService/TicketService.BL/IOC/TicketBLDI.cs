using Microsoft.Extensions.DependencyInjection;
using TicketService.BL.Implementation;
using TicketService.BL.Interface;

namespace TicketService.BL.IOC
{
    public static class TicketBLDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            _ = services.AddTransient<IUserAccountService, UserAccountService>();
            _ = services.AddTransient<IJwtService, JwtService>();
            return services;
        }
    }
}
