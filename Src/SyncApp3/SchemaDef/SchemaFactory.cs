using System.Linq;
using Dafist.Engine.Schemas.Mappings;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Top;

namespace SyncApp3.SchemaDef
{
    public static class SchemaFactory
    {
        public static Schema Create()
        {
            return new Schema(new[]
            {
                CreateComment(),
                CreateTarget()
            });
        }

        static SourceEntity CreateComment()
        {
            var sourceEntity = new SourceEntity(
                    name: "Commentm",
                    idFields: new[] { "Id" },
                    ordinaryFields: new[] { "Text", "CategoryId", "MoodId", "AuthorId", "AuthorScore" });


            sourceEntity.MapOnlyToIdentical(targetEntityName: "Comment3");

            return sourceEntity;
        }

        static SourceEntity CreateTarget()
        {
            var sourceEntity = new SourceEntity(
                    name: "MaTarget",
                    idFields: new string[]{}, 
                    ordinaryFields: new[] {"Text"});


            sourceEntity.MapOnlyToIdentical(targetEntityName: "MzTarget");

            return sourceEntity;
        }
    }
}
