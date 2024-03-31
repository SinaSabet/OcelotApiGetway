using Consul;
using System.Runtime.CompilerServices;

namespace PushNotiffication.Email.ServiceDiscovery
{
    public static class ConsulRegistration
    {
        public static IServiceCollection Register(this IServiceCollection service)
        {
            service.AddHostedService<ServiceDiscoveryHosted>();
            service.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(config =>
            {
                config.Address = Config.ServiceDiscoveryAddress;

            })

            );

            return service;
        }
    }
}
