using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;

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
                var timeSpan = TimeSpan.FromSeconds(rawDataValue);
                return new DateTime(timeSpan.Ticks);
                //return new DateTime(0, 0, 0, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
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