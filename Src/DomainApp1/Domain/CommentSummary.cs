namespace DomainApp1.Domain
{
    public class CommentSummary
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int MoodId { get; set; }
        public CommentSummary(int id, string text, int moodId)
        {
            Id = id;
            Text = text;
            MoodId = moodId;
        }
    }
}
