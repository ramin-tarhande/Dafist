using DomainApp1.Domain;
using EasyNetQ;

namespace DomainApp1.Adapters
{
    class RbIcdPublisher : IcdPublisher
    {
        private readonly IBus bus;
        public RbIcdPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(ImportantCommentDetected icd)
        {
            var topic = icd.Responsible.DepartmentId.ToString();

            bus.Publish(icd, topic);
        }
    }
}
