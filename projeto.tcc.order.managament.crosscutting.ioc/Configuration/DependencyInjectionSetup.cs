using Microsoft.Extensions.DependencyInjection;
using System;

namespace projeto.tcc.order.managament.crosscutting.ioc.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services, AppSettings appSettings)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services, appSettings);
        }
    }
}
