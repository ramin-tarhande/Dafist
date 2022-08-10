using DomainApp1.Domain;
using EasyNetQ;
using Dafist.Shared;
using Dafist.Shared.Messages;
using Dafist.Shared.Tools;

namespace DomainApp1.Adapters
{
    class Listener
    {
        private readonly IBus bus;
        private readonly CommentProcessor processor;
        private readonly Da1Settings settings;
        public Listener(CommentProcessor processor, IBus bus, Da1Settings settings)
        {
            this.settings = settings;
            this.processor = processor;
            this.bus = bus;
        }

        public void Start()
        {
            bus.Subscribe<UpdateMessage>("DomainApp1", HandleMessage, c =>
            {
                c.WithAutoDelete(settings.RabbitMq_AutoDeleteQueue)
                 .WithTopic(settings.RabbitMq_Topic);

                //c.WithTopic(string.Format("Commentm.{0}", UpdateType.Created));
            });
        }

        void HandleMessage(UpdateMessage msg)
        {
            if (msg.UpdateType != UpdateType.Deleted)
            {
                var c = msg.Data.ToObject<Comment>();
                
                processor.Process(c);    
            }
        }
    }
}
