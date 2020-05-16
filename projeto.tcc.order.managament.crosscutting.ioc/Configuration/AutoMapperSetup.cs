using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using projeto.tcc.order.managament.application.AutoMapper.AssetsProfile;
using System;

namespace projeto.tcc.order.managament.crosscutting.ioc.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AssetsToGetAllAssetsResponseDto));
        }
    }
}
