namespace Dafist.SqlCommon
{
    public struct Sql
    {
        public string Text { get; private set; }
        public object Parameters { get; private set; }
        public Sql(string text, object parameters=null):this()
        {
            Text = text;
            Parameters = parameters;
        }
    }
}
