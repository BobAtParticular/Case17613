using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case17613.Messages;
using NServiceBus;

namespace Case17613.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("Case17613.Client");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Messages"));
            busConfiguration.EnableInstallers();

            using (var bus = Bus.CreateSendOnly(busConfiguration))
            {
                var sagaId = Guid.NewGuid();

                Console.WriteLine("Press any key to start a saga: " + sagaId);
                Console.ReadKey();
                bus.Send("Case17613.Host", new StartTheSaga
                {
                    SagaId = sagaId
                });

                Console.WriteLine("Press any key to complete the saga");
                Console.ReadKey();

                bus.Send("Case17613.Host", new CompleteTheSaga
                {
                    SagaId = sagaId
                });
            }
        }
    }
}
