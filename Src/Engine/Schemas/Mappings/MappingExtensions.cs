using Dafist.Engine.Schemas.Source;

namespace Dafist.Engine.Schemas.Mappings
{
    public static class MappingExtensions
    {
        public static void MapOnlyTo(this SourceEntity source, TargetEntity target)
        {
            source.SetFixedMapping(
                MappingFactory.Create(source, target));
        }

        public static void MapOnlyToIdentical(this SourceEntity source, string targetEntityName = null)
        {
            source.SetFixedMapping(
                MappingFactory.CreateIdentical(source, targetEntityName));
        }
    }
}
