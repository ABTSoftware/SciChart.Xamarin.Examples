using System;
using System.Globalization;

namespace SciChart.iOS.Charting
{
    public static class ComparableUtil
    {
        private static DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static double ToDouble(IComparable comparable)
        {
            if (comparable is DateTime)
            {
                TimeSpan diff = ((DateTime)comparable).ToUniversalTime() - _epoch;
                double secondsSince1970 = Math.Floor(diff.TotalSeconds);

                return secondsSince1970;
            }
            if (comparable is TimeSpan)
            {
                throw new NotSupportedException("TimeSpan isn't supported");
            }

            return Convert.ToDouble(comparable, CultureInfo.InvariantCulture);
        }

        public static IComparable FromDouble(double rawDataValue, Type type)
        {
            IComparable result = null;

            if (type == typeof(DateTime))
            {
                return _epoch.AddSeconds(rawDataValue);
            }
            else if (type == typeof(TimeSpan))
            {
                throw new NotSupportedException("TimeSpan isn't supported");
            }
            else
            {
                result = (IComparable)Convert.ChangeType(rawDataValue, type, CultureInfo.InvariantCulture);
            }

            return result;
        }
    }
}