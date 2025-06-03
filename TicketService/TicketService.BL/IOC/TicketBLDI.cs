using Microsoft.Extensions.DependencyInjection;
using Stripe;
using TicketService.BL.Implementation;
using TicketService.BL.Interface;
using CheckoutService = TicketService.BL.Implementation.CheckoutService;
using EventService = TicketService.BL.Implementation.EventService;

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
            _ = services.AddTransient<ITicketService, TicketsService>();
            _ = services.AddTransient<ITicketCategoryService, TicketCategoryService>();
            _ = services.AddTransient<ICheckoutService, CheckoutService>();
            _ = services.AddTransient<IPaymentService, PaymentService>();
            _ = services.AddTransient<IStripePaymentService, StripePaymentService>();

            _ = services.AddTransient<IQRTicketService, QrTicketService>();
            _ = services.AddTransient<IPaymentResponseService, PaymenetResponseService>();

            _ = services.AddTransient<RefundService>();
            return services;
        }
    }
}
