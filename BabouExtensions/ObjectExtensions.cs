using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BabouExtensions
{
    /// <summary>
    /// Object Extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns an object as string or the default value if source.HasValue is false
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToStringOrDefault<T>(this T? source, string defaultValue) where T : struct
        {
            return source?.ToString() ?? defaultValue;
        }

        /// <summary>
        /// Returns an object as string or the default value if source.HasValue is false. If source has a source, then the resulting string will be formatted in desired output
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToStringOrDefault<T>(this T? source, string format, string defaultValue)
            where T : struct, IFormattable
        {
            return source?.ToString(format, CultureInfo.CurrentCulture) ?? defaultValue;
        }
    }
}
