using Microsoft.Extensions.DependencyInjection;
using TicketService.DAL.Implemenatation;
using TicketService.DAL.Interface;

namespace TicketService.DAL.IOC
{
    public static class TicketDALDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            _ = services.AddScoped<IUserAcccountRepository, UserAccountRepository>();
            _ = services.AddScoped<IEventRepository, EventRepository>();
            return services;
        }
    }
}
