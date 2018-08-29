using AzureFunction.Infrastructure.Repositories;
using AzureFunction.Infrastructure.Repositories.Interfaces;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureFunction.App
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        public IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            #region DependencyContainer
            services.AddTransient<IMyRepository, MyRepository>();
            #endregion


            return services.BuildServiceProvider(true);
        }
    }
}
