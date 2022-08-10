using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dafist.Shared.Tools
{
    public static class ObjectDictionaryConversions
    {
        
        public static T ToObject<T>(this IDictionary<string, object> dict) where T : new()
        {
            return ToObject(dict, ()=>new T());
        } 

        // http://www.herlitz.nu/2012/12/31/mapping-dictionary-to-typed-object-using-c/
        public static T ToObject<T>(this IDictionary<string, object> dict, Func<T> factory)
        {
            var x = factory();

            foreach (var pair in dict)
            {
                var prop = x.GetType().GetProperty(pair.Key);
                if (prop!=null)
                {
                    var propertyType = prop.PropertyType;

                    // Fix nullables...
                    var newType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                    
                    // ...and change the type
                    object newValue = Convert.ChangeType(pair.Value, newType);
                    prop.SetValue(x, newValue, null);    
                }
            }

            return x;
        }

        // https://stackoverflow.com/questions/4943817/mapping-object-to-dictionary-and-vice-versa
        public static IDictionary<string, object> AsDictionary(this object source,
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance) //| BindingFlags.DeclaredOnly 
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }
    }
}
