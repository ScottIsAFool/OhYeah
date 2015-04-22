using System;
using System.Collections.Generic;

namespace OhYeah.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static List<DateTime> GetPreviousYears(this DateTime today)
        {
            var years = today.Year - 2004;
            var yearLists = new List<DateTime>();

            for (var i = 0; i < years; i++)
            {
                yearLists.Add(today.AddYears(-i));
            }

            return yearLists;
        }

        public static double ToEpoch(this DateTime dateTime)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixTimestamp = System.Convert.ToInt64((dateTime.Date.AddDays(1) - date).TotalSeconds);

            return unixTimestamp;
        }

        public static DateTime FromEpoch(this float epochTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(epochTime).ToLocalTime();
        }
    }
}