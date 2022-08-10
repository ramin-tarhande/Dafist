namespace DomainApp1.Domain
{
    class ImportantCommentSpecification : Specificaiton
    {
        private readonly Da1Settings settings;
        public ImportantCommentSpecification(Da1Settings settings)
        {
            this.settings = settings;
        }

        public bool IsSatisfiedBy(Comment c)
        {
            return TopAuthor(c) &&
                   VeryBadMood(c);
        }

        private bool TopAuthor(Comment c)
        {
            return c.AuthorScore >= settings.AuthorScoreThreshold;
        }

        private bool VeryBadMood(Comment c)
        {
            return c.MoodId <= settings.MoodThreshold;
        }
    }
}
