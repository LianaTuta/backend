using Microsoft.Extensions.DependencyInjection;
using TicketService.ApiClient.Implementation;
using TicketService.ApiClient.Interface;

namespace TicketService.ApiClient.IOC
{
    public static class TicketApiClientDI
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services)
        {
            _ = services.AddScoped<IGoogleClient, GoogleClient>();
            return services;
        }
    }
}
