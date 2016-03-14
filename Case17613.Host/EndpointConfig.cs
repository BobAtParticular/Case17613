
using NServiceBus.Persistence;

namespace Case17613.Host
{
    using NServiceBus;
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<JsonSerializer>();
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Messages"));
            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}
