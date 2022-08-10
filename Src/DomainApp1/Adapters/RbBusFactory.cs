using EasyNetQ;
using Dafist.Shared.Messages;

namespace DomainApp1.Adapters
{
    class RbBusFactory
    {
        public static IBus Create(Da1Settings settings)
        {
            var cs = string.Format("host={0}", settings.RabbitMq_Host);

            var bus = RabbitHutch.CreateBus(cs);

            bus.Advanced.Container.Resolve<IConventions>().ExchangeNamingConvention = t => 
                t==typeof(UpdateMessage)?
                settings.RabbitMq_ReceiveExchange:
                settings.RabbitMq_SendExchange;

            return bus;
        }
    }
}
