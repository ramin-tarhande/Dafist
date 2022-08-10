using Dafist.Engine.Schemas.Top;

namespace SyncApp2.SchemaDef
{
    public class SchemaFactory
    {
        private readonly MySourceSf mySourceSf;
        private readonly CommentSf commentSf;
        public SchemaFactory(MySourceSf mySourceSf, CommentSf commentSf)
        {
            this.mySourceSf = mySourceSf;
            this.commentSf = commentSf;
        }

        public Schema Create()
        {
            return new Schema(new[]
            {
                mySourceSf.Create(),
                commentSf.Create(),
            });
        }
    }
}
