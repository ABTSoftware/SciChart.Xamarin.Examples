using System;

namespace SciChart.Core.Utility
{
    public static class DateTimeExtensions
    {
        private static readonly long JavaDateTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime.Ticks - JavaDateTicks)/TimeSpan.TicksPerMillisecond;
        }

        public static Java.Util.Date ToDate(this DateTime dateTime) 
        {
            return new Java.Util.Date(dateTime.ToUnixTime());
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            return new DateTime(unixTime*TimeSpan.TicksPerMillisecond + JavaDateTicks);
        }

        public static DateTime FromDate(this Java.Util.Date date)
        {
            return date.Time.FromUnixTime();
        }
    }
}