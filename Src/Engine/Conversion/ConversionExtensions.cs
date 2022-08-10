using System;

namespace Dafist.Engine.Conversion
{
    public static class ConversionExtensions
    {
        public static string AsString(this object x)
        {
            return Convert.ToString(x);
        }

        public static int AsInt(this object x)
        {
            return Convert.ToInt32(x);
        }

        public static DateTime AsDateTime(this object x)
        {
            return Convert.ToDateTime(x);
        }

        public static TimeSpan AsTimeSpan(this object x)
        {
            if (x==null)
            {
                return TimeSpan.Zero;
            }

            return TimeSpan.Parse(x.ToString());
        }
    }
}
