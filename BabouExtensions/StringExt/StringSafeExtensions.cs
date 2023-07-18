using System;
using System.Globalization;

namespace BabouExtensions
{
    /// <summary>
    /// Extension method on Safe (non-error throwing, except GIGO) string operations
    /// </summary>
    public static class StringSafe
    {
        /// <summary>
        /// Trims and converts the <paramref name="source"/> string based on given culture 
        /// (if not supplied then <seealso cref="CultureInfo.CurrentCulture"/> is used). 
        /// If null, returns the provided <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to operate on</param>
        /// <param name="defaultValue">return value in case, supplied value is null</param>
        /// <param name="culture">Culture to use, if null or not supplied, then <seealso cref="CultureInfo.CurrentCulture"/> is used.</param>
        public static string ToTrimmedUpperSafe(this string source, string defaultValue = "", CultureInfo culture = null)
        {
            return source?.Trim().ToUpper(culture ?? CultureInfo.CurrentCulture) ?? defaultValue;
        }

        /// <summary>
        /// Trims and converts the <paramref name="source"/> string based on given culture 
        /// (if not supplied then <seealso cref="CultureInfo.CurrentCulture"/> is used). 
        /// If null, returns the provided <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to operate on</param>
        /// <param name="defaultValue">return value in case, supplied value is null</param>
        /// <param name="culture">Culture to use, if null or not supplied, then <seealso cref="CultureInfo.CurrentCulture"/> is used.</param>
        public static string ToTrimmedLowerSafe(this string source, string defaultValue = "", CultureInfo culture = null)
        {
            return source?.Trim().ToLower(culture ?? CultureInfo.CurrentCulture) ?? defaultValue;
        }

        /// <summary>
        /// If value is null <seealso cref="string.Empty"/> is returned else trimmed string.
        /// <para>Also check <seealso cref="TrimSafeOrNull"/> and <seealso cref="TrimSafeOrDefault"/></para>
        /// </summary>
        /// <param name="source">Value to trim safe</param>
        /// <param name="trimChars">Optional. when not given any char set,
        /// whitespaces will be removed</param>
        public static string TrimSafeOrEmpty(this string source, params char[] trimChars)
        {
            return source.TrimSafeOrDefault(string.Empty, trimChars);
        }

        /// <summary>
        /// If value is null, null is returned else trimmed string.
        /// <para>Also check <seealso cref="TrimSafeOrEmpty"/> and <seealso cref="TrimSafeOrDefault"/></para>
        /// </summary>
        /// <param name="source">Value to trim safe</param>
        /// <param name="trimChars">Optional. when not given any char set,
        /// whitespaces will be removed</param>
        public static string TrimSafeOrNull(this string source, params char[] trimChars)
        {
            return source.TrimSafeOrDefault(null, trimChars);
        }

        /// <summary>
        /// If value is null <paramref name="defaultValue"/> is returned else trimmed string.
        /// <para>Also check <seealso cref="TrimSafeOrEmpty"/> and <seealso cref="TrimSafeOrNull"/></para>
        /// </summary>
        /// <param name="source">Value to trim safe</param>
        /// <param name="defaultValue">Default value to return when source is null.</param>
        /// <param name="trimChars">Optional. When not given any char set,
        /// whitespaces will be removed</param>
        public static string TrimSafeOrDefault(this string source, string defaultValue, params char[] trimChars)
        {
            return source?.Trim(trimChars) ?? defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="bool"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool ToOrDefault(this string source, bool defaultValue)
        {
            return source.TryTo(out bool value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="int"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static int ToOrDefault(this string source, int defaultValue)
        {
            return source.TryTo(out int value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="long"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static long ToOrDefault(this string source, long defaultValue)
        {
            return source.TryTo(out long value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="byte"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static byte ToOrDefault(this string source, byte defaultValue)
        {
            return source.TryTo(out byte value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="sbyte"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static sbyte ToOrDefault(this string source, sbyte defaultValue)
        {
            return source.TryTo(out sbyte value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="short"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static short ToOrDefault(this string source, short defaultValue)
        {
            return source.TryTo(out short value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ushort"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static ushort ToOrDefault(this string source, ushort defaultValue)
        {
            return source.TryTo(out ushort value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="uint"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static uint ToOrDefault(this string source, uint defaultValue)
        {
            return source.TryTo(out uint value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ulong"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static ulong ToOrDefault(this string source, ulong defaultValue)
        {
            return source.TryTo(out ulong value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="float"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static float ToOrDefault(this string source, float defaultValue)
        {
            return source.TryTo(out float value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="double"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static double ToOrDefault(this string source, double defaultValue)
        {
            return source.TryTo(out double value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="decimal"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        public static decimal ToOrDefault(this string source, decimal defaultValue)
        {
            return source.TryTo(out decimal value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/> value. If parsing is successful
        /// then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        /// <returns>True if parsing is successful else false</returns>
        public static DateTime ToOrDefault(this string source, DateTime defaultValue)
        {
            return source.TryTo(out DateTime value) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value along with
        /// <seealso cref="Enum.IsDefined"/> check. Useful when it is not certain whether the parsed value 
        /// will result in existing define enum value (example when parsing integers back to enum coming from outside).
        /// If parsing is successful then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// <para>Also check <seealso cref="StringTryTo.TryToEnumUnchecked{T}(string,out T,bool)"/>,
        /// <seealso cref="StringTryTo.TryToEnumUnchecked{T}(string,out T?,bool)"/>,
        /// <seealso cref="StringTryTo.TryToEnum{T}(string,out T,bool)"/> and
        /// <seealso cref="StringTryTo.TryToEnum{T}(string,out T?,bool)"/> methods</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        /// <param name="ignoreCase">true to ignore case, else false to consider string casing</param>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static T ToEnumOrDefault<T>(this string source, T defaultValue, bool ignoreCase = true)
            where T : struct
        {
            return source.TryToEnum(out T value, ignoreCase) ? value : defaultValue;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value (NOTE: <seealso cref="Enum.IsDefined"/> check
        /// is NOT performed). Useful when it is known for sure that the parsed value is among existing value..
        /// If parsing is successful then returns the parsed value else returns the <paramref name="defaultValue"/>.
        /// <para>Also check <seealso cref="StringTryTo.TryToEnumUnchecked{T}(string,out T,bool)"/>,
        /// <seealso cref="StringTryTo.TryToEnumUnchecked{T}(string,out T?,bool)"/>,
        /// <seealso cref="StringTryTo.TryToEnum{T}(string,out T,bool)"/> and
        /// <seealso cref="StringTryTo.TryToEnum{T}(string,out T?,bool)"/> methods</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="defaultValue">Default value to return when parsing fails</param>
        /// <param name="ignoreCase">true to ignore case, else false to consider string casing</param>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static T ToEnumUncheckedOrDefault<T>(this string source, T defaultValue, bool ignoreCase = true)
            where T : struct
        {
            return source.TryToEnumUnchecked(out T value, ignoreCase) ? value : defaultValue;
        }
    }
}
