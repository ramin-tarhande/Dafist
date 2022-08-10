namespace DomainApp1.Domain
{
    public class ImportantCommentDetected : DomainEvent
    {
        public CommentSummary Comment { get; set; }
        public Responsible Responsible { get; set; }

        internal ImportantCommentDetected(CommentSummary c, Responsible r)
        {
            Comment = c;
            Responsible = r;
        }
    }
}
