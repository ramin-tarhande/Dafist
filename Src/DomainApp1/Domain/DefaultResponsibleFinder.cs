namespace DomainApp1.Domain
{
    class DefaultResponsibleFinder : ResponsibleFinder
    {
        private readonly Responsible responsible1,responsible2;
        public DefaultResponsibleFinder()
        {
            responsible1 = new Responsible(7, 701);
            responsible2 = new Responsible(8, 801);
        }

        public Responsible Find(Comment comment)
        {
            return comment.CategoryId == 0 ? responsible1 : responsible2;
        }
    }
}
