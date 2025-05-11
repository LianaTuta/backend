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
            _ = services.AddTransient<IEventService, EventService>();
            _ = services.AddTransient<IOrderService, OrderService>();
            _ = services.AddTransient<IEventDetailsService, EventDetailsService>();
            _ = services.AddTransient<IEventScheduleService, EventScheduleService>();
            _ = services.AddTransient<IEventTypeService, EventTypeService>();
            _ = services.AddTransient<IValidationService, ValidationService>();
            return services;
        }
    }
}
