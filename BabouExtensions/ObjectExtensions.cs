using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

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

        /// <summary>
        /// Gets the Description attribute of an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetDescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
