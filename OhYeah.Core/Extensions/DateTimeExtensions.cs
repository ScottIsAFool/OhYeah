using System;
using System.Collections.Generic;

namespace OhYeah.Core.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static List<DateTime> GetPreviousYears(this DateTime today)
        {
            today = today.AddYears(-1);
            var years = today.Year - 2004;
            var yearLists = new List<DateTime>();

            for (var i = 0; i < years; i++)
            {
                yearLists.Add(today.AddYears(-i));
            }

            return yearLists;
        }

        public static long ToEpoch(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - UnixEpoch).TotalSeconds;
        }

        public static DateTime FromEpoch(this long epochTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(epochTime).ToLocalTime();
        }
    }
}