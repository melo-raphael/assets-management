using Microsoft.Extensions.DependencyInjection;
using projeto.tcc.order.managament.data.Context;
using System;

namespace projeto.tcc.order.managament.crosscutting.ioc.Configuration
{
    public static class DataBaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
        }
    }
}
