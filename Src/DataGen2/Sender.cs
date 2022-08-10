using System;
using DataGen2.Properties;
using EasyNetQ;

namespace DataGen2
{
    class Sender:IDisposable
    {
        private IBus bus;
        
        public void Start()
        {
            var settings = Settings.Default;
            var cs = string.Format("host={0}", settings.RabbitMq_Host);

            bus = RabbitHutch.CreateBus(cs);

            bus.Advanced.Container.Resolve<IConventions>().ExchangeNamingConvention =
                info => settings.RabbitMq_Exchange;

        }

        public void Send(object msg)
        {
            bus.Publish(msg);
        }

        public void Dispose()
        {
            if (bus != null)
            {
                bus.Dispose();
            }
        }
    }
}
