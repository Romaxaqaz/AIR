using System;

namespace Domain.Lab4
{
    public static class LocalDataTime
    {
        public static string ToLocalDateTime(this DateTime time)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Belarus Standard Time");

            string times = time.Hour.ToString() + "-" +
                           time.Minute.ToString() + "-" +
                           time.Second.ToString();

            string date = time.Year.ToString() + ":" +
                          time.Month.ToString() + ":" +
                          time.Day.ToString();

            string result = date + " " + times + " " + timeZone.BaseUtcOffset.ToString().Substring(0, 5);
            return result;
        }
    }
}
