using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.DAL.Implemenatation;
using TicketService.DAL.Interface;

namespace TicketService.DAL.IOC
{
    public static class TicketDALDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserAcccountRepository, UserAccountRepository>();
            return services;
        }
    }
}
