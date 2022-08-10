using System;
using EasyNetQ;
using Dafist.Engine.Get.Receive;
using Dafist.Engine.Updates;
using Dafist.MessagingCommon;

namespace Dafist.RabbitAdp.Get
{
    class RbReceiver<T> : Receiver where T : class
    {
        public event Action<SourceUpdate> Received;

        private IBus bus;

        private readonly MessageConverter<T> messageConverter;
        private readonly string subscriptionId;
        private readonly RbReceiveSettings settings;
        public RbReceiver(MessageConverter<T> messageConverter, string subscriptionId, RbReceiveSettings settings)
        {
            this.messageConverter = messageConverter;
            this.subscriptionId = subscriptionId;
            this.settings = settings;
        }

        public void Start()
        {
            bus = RbBusFactory.Start(settings);

            bus.Subscribe<T>(subscriptionId, HandleMessage,
                c =>
                {
                    c.WithAutoDelete(settings.RabbitMq_AutoDeleteQueue);
                    if (!string.IsNullOrEmpty(settings.RabbitMq_Topic))
                    {
                        c.WithTopic(settings.RabbitMq_Topic);   
                    }
                });
        }

        void HandleMessage(T msg)
        {
            var update = messageConverter.Convert(msg);
            if (update!=null)
            {
                FireReceived(update);
            }
        }

        public void Stop()
        {
            if (bus != null)
            {
                bus.Dispose();
            }
        }

        void FireReceived(SourceUpdate update)
        {
            if (Received!=null)
            {
                Received(update);
            }
        }
    }
}
