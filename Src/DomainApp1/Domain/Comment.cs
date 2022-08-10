namespace DomainApp1.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public int MoodId { get; set; }
        public int AuthorId { get; set; }
        public int AuthorScore { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} Text:{1} Category:{2} Mood:{3} Author:{4} AuthorScore:{5}",
                Id, Text, CategoryId, MoodId, AuthorId, AuthorScore);
        }

        public CommentSummary Summary()
        {
            return new CommentSummary(Id,Text,MoodId);
        }
    }
}
