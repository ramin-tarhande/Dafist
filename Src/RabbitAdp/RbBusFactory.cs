using EasyNetQ;

namespace Dafist.RabbitAdp
{
    class RbBusFactory
    {
        public static IBus Start(RbSettings settings)
        {
            var cs = string.Format("host={0}", settings.RabbitMq_Host);

            var bus = RabbitHutch.CreateBus(cs);

            bus.Advanced.Container.Resolve<IConventions>().ExchangeNamingConvention = 
                info => settings.RabbitMq_Exchange;

            return bus;
        }
    }
}
