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
            _ = services.AddScoped<IOrderRepository, OrderRepository>();
            _ = services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            _ = services.AddScoped<IEventScheduleRepository, EventScheduleRepository>();
            _ = services.AddScoped<IEventDetailsRepository, EventDetailsRepository>();
            _ = services.AddScoped<ITicketCategoryRepository, TicketCategoryRepository>();
            _ = services.AddScoped<ITicketRepository, TicketRepository>();
            _ = services.AddScoped<IUserPaymentRepository, UserPaymentRepository>();
            return services;
        }
    }
}
