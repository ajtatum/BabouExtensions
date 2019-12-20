using System;
using System.Globalization;

namespace BabouExtensions
{
    /// <summary>
    /// Extension methods to parse string to different structs.
    /// </summary>
    public static class StringTryTo
    {
        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="bool"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out bool value)
        {
            return bool.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Type"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="ignoreCase">true to ignore string casing else false to consider casing</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out Type value, bool ignoreCase = true)
        {
            value = default(Type);
            return !(source is null) &&
                   !((value = Type.GetType(source, false, ignoreCase)) is null);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="int"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out int value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return int.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="long"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out long value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return long.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="byte"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out byte value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return byte.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="sbyte"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out sbyte value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return sbyte.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="short"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out short value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return short.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ushort"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ushort value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return ushort.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="uint"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out uint value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return uint.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ulong"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ulong value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return ulong.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="float"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out float value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return float.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="double"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out double value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return double.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="decimal"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out decimal value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            return decimal.TryParse(source, style, formatProvider, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/> value using exact parsing.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="format">Date format string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime value, string format,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            return DateTime.TryParseExact(source, format, formatProvider, style, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/> value using exact parsing
        /// based on given set of formats.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="formats">Date format strings</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime value, string[] formats,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            return DateTime.TryParseExact(source, formats, formatProvider, style, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime value,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            return DateTime.TryParse(source, formatProvider, style, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value.
        /// <para>Does not validate the existence of Parsed value. Could be useful when
        /// it is known for sure that the Parsed value is among existing value.</para>
        /// <para>Also check <see cref="TryToEnum{T}(string,out T,bool)"/>
        /// and <seealso cref="StringSafe.ToEnumOrDefault{T}"/> and 
        /// <seealso cref="StringSafe.ToEnumUncheckedOrDefault{T}"/> methods</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="ignoreCase">True to ignore case, else false to consider string casing</param>
        /// <returns>True if parsing is successful else false</returns>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static bool TryToEnumUnchecked<T>(this string source, out T value, bool ignoreCase = true)
            where T : struct
        {
            return Enum.TryParse(source, ignoreCase, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value.
        /// <para>If parsing is successful then calls <seealso cref="Enum.IsDefined"/>. Useful when
        /// it is not certain whether the Parsed value will result in existing define enum value.
        /// (example when parsing integers back to enum coming from outside)</para>
        /// <para>Also check <see cref="TryToEnumUnchecked{T}(string,out T,bool)"/>
        /// and <seealso cref="StringSafe.ToEnumOrDefault{T}"/> and 
        /// <seealso cref="StringSafe.ToEnumUncheckedOrDefault{T}"/> methods</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="ignoreCase">True to ignore case, else false to consider string casing</param>
        /// <returns>True if parsing is successful else false</returns>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static bool TryToEnum<T>(this string source, out T value, bool ignoreCase = true)
            where T : struct
        {
            return source.TryToEnumUnchecked(out value, ignoreCase) &&
                   Enum.IsDefined(typeof(T), value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="bool"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="bool"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="bool"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out bool? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out bool parsedValue)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="int"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="int"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="int"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out int? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out int parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="long"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="long"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="long"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out long? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out long parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="byte"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="byte"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="byte"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out byte? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out byte parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="sbyte"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="sbyte"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="sbyte"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out sbyte? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out sbyte parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="short"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="short"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="short"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out short? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out short parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ushort"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="ushort"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="ushort"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ushort? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out ushort parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="uint"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="uint"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="uint"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out uint? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out uint parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ulong"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="ulong"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="ulong"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ulong? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out ulong parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="float"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="float"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="float"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out float? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out float parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="double"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="double"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="double"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out double? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out double parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="decimal"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="decimal"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="decimal"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="style">Style to use during parsing</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out decimal? value, NumberStyles style = NumberStyles.Any,
            IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out decimal parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/>? value using exact parsing.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="DateTime"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="DateTime"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="format">Date format string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime? value, string format,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out DateTime parsedValue, format, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/>? value using exact parsing
        /// based on given set of formats.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="DateTime"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="DateTime"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="formats">Date format strings</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime? value, string[] formats,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out DateTime parsedValue, formats, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/>? value.
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <seealso cref="DateTime"/> with
        /// <paramref name="value"/> as the parsed outcome.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <seealso cref="DateTime"/>
        /// with <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="style">DateTime style</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime? value,
            DateTimeStyles style = DateTimeStyles.AssumeLocal, IFormatProvider formatProvider = null)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryTo(out DateTime parsedValue, style, formatProvider)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value.
        /// <para>Does not validate the existence of Parsed value. Could be useful when
        /// it is known for sure that the Parsed value is among existing value.</para>
        /// <para>Also check <see cref="TryToEnum{T}(string,out T?,bool)"/>,
        /// <seealso cref="StringSafe.ToEnumOrDefault{T}"/> and 
        /// <seealso cref="StringSafe.ToEnumUncheckedOrDefault{T}"/> methods</para>
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <typeparamref name="T"/> with
        /// <paramref name="value"/> as the parsed outcome without checking whether it is defined or not.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <typeparamref name="T"/>
        /// and <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="ignoreCase">True to ignore case, else false to consider string casing</param>
        /// <returns>True if parsing is successful else false</returns>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static bool TryToEnumUnchecked<T>(this string source, out T? value, bool ignoreCase = true)
            where T : struct
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryToEnumUnchecked(out T parsedValue, ignoreCase)) return false;
            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value.
        /// <para>If parsing is successful then calls <seealso cref="Enum.IsDefined"/>. Useful when
        /// it is not certain whether the Parsed value will result in existing define enum value.
        /// (example when parsing integers back to enum coming from outside)</para>
        /// <para>Also check <see cref="TryToEnumUnchecked{T}(string,out T?,bool)"/>
        /// and <seealso cref="StringSafe.ToEnumOrDefault{T}"/> and 
        /// <seealso cref="StringSafe.ToEnumUncheckedOrDefault{T}"/> methods</para>
        /// <para>Returns true when:
        /// <list type="bullet">
        /// <item><description><paramref name="source"/> is <seealso cref="string.IsNullOrWhiteSpace"/>
        /// and out <paramref name="value"/> as null.</description></item>
        /// <item><description><paramref name="source"/> is parsable to <typeparamref name="T"/> with
        /// <paramref name="value"/> as the parsed outcome among defined values.</description></item>
        /// </list></para>
        /// <para>Returns false when <paramref name="source"/> is NOT parsable to <typeparamref name="T"/>
        /// or the value does not exits among defined value, in this case <paramref name="value"/> as null.</para>
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <param name="ignoreCase">True to ignore case, else false to consider string casing</param>
        /// <returns>True if parsing is successful else false</returns>
        /// <typeparam name="T">Enum type</typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static bool TryToEnum<T>(this string source, out T? value, bool ignoreCase = true)
            where T : struct
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) return true;
            if (!source.TryToEnum(out T parsedValue, ignoreCase)) return false;
            value = parsedValue;
            return true;
        }
    }
}
