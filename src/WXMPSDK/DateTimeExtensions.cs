using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class DateTimeExtensions
    {
        private readonly static DateTime beginTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToWXTime(this DateTime dt)
        {
            return (long)Math.Round(dt.ToUniversalTime().Subtract(beginTime).TotalSeconds);
        }

        public static DateTime ToNetCoreTime(this long dt)
        {
            return beginTime.AddSeconds(dt).ToLocalTime();
        }
    }
}
