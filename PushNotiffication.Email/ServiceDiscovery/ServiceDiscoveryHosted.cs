
using Consul;

namespace PushNotiffication.Email.ServiceDiscovery
{
    public class ServiceDiscoveryHosted : IHostedService
    {
        private readonly IConsulClient _consulClient;
        public ServiceDiscoveryHosted(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var registerModel = new AgentServiceRegistration
            {
                ID=Config.ServiceId,
                Address=Config.ServiceAddress.Host,
                Name=Config.ServiceName,    
                Port=Config.ServiceAddress.Port,

            };

            await _consulClient.Agent.ServiceDeregister(Config.ServiceId, cancellationToken);
            await _consulClient.Agent.ServiceRegister(registerModel, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _consulClient.Agent.ServiceDeregister(Config.ServiceId, cancellationToken);
        }
    }
}
