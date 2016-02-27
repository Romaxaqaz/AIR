using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public static class LocalDataTime
    {
        public static string ToLocalDateTime(this DateTime time)
        {
            TimeZoneInfo zoneInfo = new TimeZoneInfo();
            string result = time.Date.ToString() + " " + time.TimeOfDay.ToString() + " " + zoneInfo.BaseUtcOffset.ToString();
            return result;
        }
    }
}
