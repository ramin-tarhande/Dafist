using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Schemas.Mappings;

namespace SyncApp4.SchemaDef
{
    public static class SchemaFactory
    {
        public static Schema Create()
        {
            return new Schema(new[]
            {
                CreateEntity(),
            });
        }

        static SourceEntity CreateEntity()
        {
            var sourceEntity = new SourceEntity(
                    name: "EmpAtd",
                    idFields: new string[] {},
                    ordinaryFields: new[] { "EmployeeId", "PunchTime"});

            var targetEntity = new TargetEntity("EmpAtd",
                new TargetField[]
                {
                    new Auto("AtdId"),
                    new Copy("EmployeeId"),
                    new Copy("PunchTime")
                });
            
            sourceEntity.MapOnlyTo(targetEntity);

            return sourceEntity;
        }
    }
}
