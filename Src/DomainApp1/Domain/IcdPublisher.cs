namespace DomainApp1.Domain
{
    public interface IcdPublisher
    {
        void Publish(ImportantCommentDetected icd);
    }
}