using Dafist.Engine.Conversion;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Schemas.Mappings;

namespace SyncApp1.SchemaDef
{
    public static class SchemaFactory
    {
        public static Schema Create()
        {
            return new Schema(new[]
            {
                CreateForSimple(),
                CreateForASource(),
            });
        }

        static SourceEntity CreateForSimple()
        {
            var sourceEntity = new SourceEntity(
                name: "Simple",
                idFields: new[] { "Id" },
                ordinaryFields: new[] { "Text" });

            sourceEntity.MapOnlyToIdentical(targetEntityName: "Simple1");
            
            return sourceEntity;
        }

        static SourceEntity CreateForASource()
        {
            var sourceEntity = new SourceEntity(
                name:"ASource",
                idFields: new[] { "Id" },
                ordinaryFields: new[] { "Title", "Description"});

            var targetEntity = new TargetEntity(
                name: "ATarget",
                fields: new TargetField[]
                {
                    new Copy("Id"),
                    new Copy("Title"),
                    new Copy("Descrip", "Description"),

                    new Custom("Together", f => f["Title"].AsString() + " -- " + f["Description"].AsString()),

                    new Constant("Extra", ":-)")
                });

            sourceEntity.MapOnlyTo(targetEntity);
            
            return sourceEntity;
        }
    }
}
