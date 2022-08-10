using log4net;

namespace DomainApp1.Domain
{
    class CommentProcessor
    {
        private readonly ResponsibleFinder responsibleFinder;
        private readonly Specificaiton specification;
        private readonly IcdPublisher icdPublisher;
        private readonly ILog log;
        public CommentProcessor(ResponsibleFinder responsibleFinder, Specificaiton specification, 
            IcdPublisher icdPublisher, ILog log)
        {
            this.responsibleFinder = responsibleFinder;
            this.specification = specification;
            this.icdPublisher = icdPublisher;
            this.log = log;
        }

        public void Process(Comment comment)
        {
            log.DebugFormat("Processing comment: {0}",comment);

            if (specification.IsSatisfiedBy(comment))
            {
                Publish(comment);
            }

            log.Debug("");
        }

        void Publish(Comment comment)
        {
            var responsible = responsibleFinder.Find(comment);

            var @event = new ImportantCommentDetected(comment.Summary(), responsible);

            LogImp(comment, responsible);

            icdPublisher.Publish(@event);
        }

        void LogImp(Comment comment, Responsible responsible)
        {
            log.Info("Important:");
            log.InfoFormat(" {0}", comment);
            log.InfoFormat(" responsible: {0}", responsible);
            log.Info("");
        }
    }
}
