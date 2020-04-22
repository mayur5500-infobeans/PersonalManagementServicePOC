using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalManagementServicePOC.Domain.Services.Implementations;
using PersonalManagementServicePOC.Domain.Services.Interfaces;
using Repository.PersonalManagementServicePOC.Repositories.Implementations;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using System;

namespace DependencyRegistrar
{
    public static class ContainerConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICommitteeService, CommitteeService>();
            services.AddTransient<ICommitteeRepository, CommitteeRepository>();
        }        
    }
}