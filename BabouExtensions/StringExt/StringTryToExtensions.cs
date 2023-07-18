using System;

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
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out int value)
        {
            return int.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="long"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out long value)
        {
            return long.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="byte"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out byte value)
        {
            return byte.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="sbyte"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out sbyte value)
        {
            return sbyte.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="short"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out short value)
        {
            return short.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ushort"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ushort value)
        {
            return ushort.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="uint"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out uint value)
        {
            return uint.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ulong"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ulong value)
        {
            return ulong.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="float"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out float value)
        {
            return float.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="double"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out double value)
        {
            return double.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="decimal"/> value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out decimal value)
        {
            return decimal.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/> value using exact parsing
        /// based on given set of formats.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime value)
        {
            return DateTime.TryParse(source, out value);
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="bool"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out bool? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out bool parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="int"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out int? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out int parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="long"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out long? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out long parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="byte"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out byte? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out byte parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="sbyte"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out sbyte? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out sbyte parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="short"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out short? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out short parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ushort"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ushort? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out ushort parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="uint"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out uint? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out uint parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="ulong"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out ulong? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out ulong parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="float"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out float? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace())
                return false;

            if (!source.TryTo(out float parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="double"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out double? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out double parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="decimal"/>? value.
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out decimal? value)
        {
            value = null;
            if (source.IsNullOrWhiteSpace())
                return false;

            if (!source.TryTo(out decimal parsedValue)) 
                return false;

            value = parsedValue;
            return true;
        }

        /// <summary>
        /// Tries parsing <seealso cref="string"/> to <seealso cref="DateTime"/>?
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="value">Parsed value</param>
        /// <returns>True if parsing is successful else false</returns>
        public static bool TryTo(this string source, out DateTime? value)
        {
            value = null;

            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryTo(out DateTime parsedValue))
                return false;

            value = parsedValue;
            return true;
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
        /// Tries parsing <seealso cref="string"/> to <seealso cref="Enum"/> value.
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
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryToEnumUnchecked(out T parsedValue, ignoreCase)) 
                return false;

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
            if (source.IsNullOrWhiteSpace()) 
                return false;

            if (!source.TryToEnum(out T parsedValue, ignoreCase)) 
                return false;

            value = parsedValue;
            return true;
        }
    }
}
