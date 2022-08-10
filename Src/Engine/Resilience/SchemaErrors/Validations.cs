using System.Collections.Generic;
using System.Linq;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    static class Validations
    {
        public static void ValidateFieldNames(this IEnumerable<string> fieldNames)
        {
            if (!fieldNames.Any())
            {
                throw new SchemaErrorException("empty field name list");
            }

            foreach (var fieldName in fieldNames)
            {
                ValidateFieldName(fieldName);
            }
        }

        public static void ValidateFieldName(this string fn)
        {
            if (string.IsNullOrWhiteSpace(fn))
            {
                throw new SchemaErrorException("Invalid field name");
            }
        }

        public static void ValidateEntityName(this string tn)
        {
            if (string.IsNullOrWhiteSpace(tn))
            {
                throw new SchemaErrorException("Invalid entity name");
            }
        }

        public static void ValidateNonEmpty<T>(this IEnumerable<T> items)
        {
            if (!items.Any())
            {
                throw new SchemaErrorException("empty list not allowed");
            }
        }

        public static void ValidateNotNull<T>(this T x)
        {
            if (x==null)
            {
                throw new SchemaErrorException("empty list not allowed");
            }
        }

    }
}
