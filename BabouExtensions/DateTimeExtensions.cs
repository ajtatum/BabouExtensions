﻿using System;
using TimeZoneConverter;

namespace BabouExtensions
{
    /// <summary>
    /// Extensions for DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines if two dates are within a range.
        /// </summary>
        /// <param name="value">The Current DateTime</param>
        /// <param name="rangeBeg">Beginning DateTime Range</param>
        /// <param name="rangeEnd">End of DateTime Range</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime value, DateTime rangeBeg, DateTime rangeEnd)
        {
            return value.Ticks >= rangeBeg.Ticks && value.Ticks <= rangeEnd.Ticks;
        }

        /// <summary>
        /// Calculates age based on DateTime specified
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime value)
        {
            var age = DateTime.Now.Year - value.Year;
            if (DateTime.Now < value.AddYears(age))
                age--;
            return age;
        }

        /// <summary>
        /// Returns a friendly version of a DateTime, ie: one second/minute/hour ago etc.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromTimeZone">The TimeZone you want to compare to, otherwise uses UTC.</param>
        /// <returns></returns>
        public static string ToReadableTime(this DateTime value, string fromTimeZone = null)
        {
            var ts = fromTimeZone == null 
                ? new TimeSpan(DateTime.UtcNow.Ticks - value.Ticks) 
                : new TimeSpan(DateTime.Now.TryGetTimeZoneDateTime(fromTimeZone).Ticks - value.Ticks);
            
            var delta = ts.TotalSeconds;

            if (delta < 60)
                return ts.Seconds == 1 ? "one second ago" : $"{ts.Seconds} seconds ago";

            if (delta < 120)
                return "a minute ago";

            if (delta < 2700) // 45 * 60
                return $"{ts.Minutes} minutes ago";

            if (delta < 5400) // 90 * 60
                return "an hour ago";

            if (delta < 86400) // 24 * 60 * 60
                return $"{ts.Hours} hours ago";

            if (delta < 172800) // 48 * 60 * 60
                return "yesterday";

            if (delta < 2592000) // 30 * 24 * 60 * 60
                return $"{ts.Days} days ago";

            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                var months = Convert.ToInt32(Math.Floor((double) ts.Days / 30));
                return months <= 1 ? "one month ago" : $"{months} months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double) ts.Days / 365));
            return years <= 1 ? "one year ago" : $"{years} years ago";
        }

        /// <summary>
        /// Returns the date as yyyy-MM-dd
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortString(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd");
        }

        static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a double Unix Time Stamp to a DateTime
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromUnix(this double unixTimeStamp)
            => _epoch.AddSeconds(unixTimeStamp).ToLocalTime();

        /// <summary>
        /// Converts DateTime.UtcNow to the current time for a specified TimeZone. Relies on package TimeZoneConverter to try and handle time zone name differences between Windows and Linux.
        /// </summary>
        /// <param name="value">The DateTime you wish to convert</param>
        /// <param name="timeZone">The TimeZone you wish to convert to.</param>
        /// <returns>Will try to convert to the timeZone specified. If an exception occurs, returns the DateTime originally specified.</returns>
        public static DateTime TryGetTimeZoneDateTime(this DateTime value, string timeZone)
        {
            if(string.IsNullOrWhiteSpace(timeZone))
                throw new ArgumentNullException(nameof(timeZone));

            try
            {
                var timeUtc = value.ToUniversalTime();
                var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZone);
                return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);
            }
            catch (Exception)
            {
                return value;
            }
        }
    }
}