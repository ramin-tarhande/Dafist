using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dafist.Engine.Schemas.Source;
using Dafist.SqlCommon;

namespace Dafist.MsSqlAdp.Get
{
    class CtSqlExpert
    {

        public Sql CreatSql(SourceEntity entity, VersionRange versionRange)
        {
            var builder = new SqlBuilder();

            var header = string.Format(
                "SELECT /**select**/ FROM CHANGETABLE(CHANGES {0},@lowerVersion) as c /**leftjoin**/ /**where**/ /**orderby**/"
                , entity.Name);

            var t = builder.AddTemplate(header, new { lowerVersion = versionRange.Lower.Value });

            builder.Select(
                FieldsFromChangeTable(entity));

            builder.Select(
                FieldsFromSourceTable(entity));

            builder.Select(
                SpecialFieldNames.ChangeVersion);

            builder.Select(
                SpecialFieldNames.ChangeOperation);
            
            var joinText = string.Format("{0} as s on {1}", entity.Name, CreateOnForJoin(entity.IdFields));

            builder.LeftJoin(joinText);

            AddWhere(versionRange, builder);

            builder.OrderBy(SpecialFieldNames.ChangeVersion);

            return new Sql(t.RawSql, t.Parameters);
        }

        
        static string FieldsFromChangeTable(SourceEntity entity)
        {
            var fields = entity.IdFields.Select(f => string.Format("c.{0} as {1}", f,PkPrefixer.Prefix(f))).ToList();
            return string.Join(",", fields);
        }

        static string FieldsFromSourceTable(SourceEntity entity)
        {
            var all = entity.AllFields.Select(f => string.Format("s.{0}", f)).ToList();
            
            return string.Join(",", all);
        }

        static string CreateOnForJoin(IEnumerable<string> idFields)
        {
            var equals = idFields.Select(f => string.Format("c.{0}=s.{0}", f)).ToList();

            return string.Join(" and ", equals);
        }

        private static void AddWhere(VersionRange versionRange, SqlBuilder builder)
        {
            var whereText = string.Format("{0}<=@upperVersion", SpecialFieldNames.ChangeVersion);

            builder.Where(whereText, new { upperVersion = versionRange.Upper.Value });
        }
    }
}
