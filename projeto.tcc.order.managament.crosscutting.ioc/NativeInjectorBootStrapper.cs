using MediatR;
using Microsoft.Extensions.DependencyInjection;
using projeto.tcc.order.managament.application;
using projeto.tcc.order.managament.data.Context;
using projeto.tcc.order.managament.data.Queries.AssetsQueries;
using projeto.tcc.order.managament.data.Repositories;
using projeto.tcc.order.managament.data.UnitOfWork;
using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using projeto.tcc.order.managament.domain.Exceptions;
using projeto.tcc.order.managament.domain.SeedWork;

namespace projeto.tcc.order.managament.crosscutting.ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, AppSettings appSettings)
        {
            RegisterData(services);
            RegisterEnvironment(services, appSettings);
            RegisterMediatR(services);
        }


        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<IAssetsRepository, AssetsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();
            //services.AddScoped<IMessengerQueue<EventMessage>, RabbitMQMessengeQueuer>();
            services.AddScoped<IAssetsQuery, AssetsQueries>();
            services.AddScoped<IOrderQuery, OrderQueries>();

        }

        private static void RegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineBehavior<,>));
        }

        private static void RegisterEnvironment(IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(x => appSettings);
        }
    }
}
