using Microsoft.Extensions.DependencyInjection;

namespace TicketService.BL.Implementation.Template.IOC
{
    public static class TicketTemplateDI
    {
        public static IServiceCollection AddTemplate(this IServiceCollection services)
        {
            _ = services.AddTransient<CancelOrderTemplate>();
            _ = services.AddTransient<PlaceOrderTemplate>();
            return services;
        }
    }
}
