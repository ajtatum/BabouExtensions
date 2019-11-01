using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BabouExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into proper title case.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string source)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());
        }

        /// <summary>
        /// Uppercases the first letter of a string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string UppercaseFirstLetter(this string source)
        {
            // Uppercase the first letter in the string.
            if (source.Length <= 0) return source;

            var array = source.ToCharArray();
            array[0] = char.ToUpper(array[0]);
            return new string(array);
        }

        /// <summary>
        /// Gets the description of an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T GetEnumValueFromDescription<T>(this string source)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            var fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                    (f, a) => new {Field = f, Att = a})
                .SingleOrDefault(a => ((DescriptionAttribute) a.Att).Description == source);
            return (T) field?.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Truncates your string and optionally adds an ellipses suffix
        /// </summary>
        /// <param name="source">Original string</param>
        /// <param name="length">How long should the string be?</param>
        /// <param name="showSuffix">Do you want to show ellipses?</param>
        /// <returns></returns>
        public static string Truncate(this string source, int length, bool showSuffix)
        {
            var truncatedString = string.Empty;

            if (!string.IsNullOrEmpty(source) && source.Length >= length)
            {
                const string suffix = "...";

                truncatedString = source.Substring(0, length);

                if (showSuffix)
                {
                    truncatedString = $"{source}{suffix}";
                }
            }
            return truncatedString;
        }

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
        /// Goes through the string and adds a space between capital letters, excluding the first character.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AddSpacesToSentence(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return string.Empty;

            var newText = new StringBuilder(source.Length * 2);
            newText.Append(source[0]);

            for (var i = 1; i < source.Length; i++)
            {
                if (char.IsUpper(source[i]) && source[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(source[i]);
            }
            return newText.ToString();
        }

        /// <summary>
        /// Returns just the digits from a string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetTheDigits(this string source) => new Regex(@"[^\d]").Replace(source, string.Empty);

        /// <summary>
        /// Returns just alpha characters.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StripSpacesAndNonAlphaNumeric(this string source) =>
            new Regex(@"[^A-Za-z0-9]+").Replace(source, string.Empty);

        /// <summary>
        /// Removes HTML from a string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StripHtml(this string source) => new Regex(@"<[^>]*>").Replace(source, " ");

        /// <summary>
        /// Removes line endings
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveLineEndings(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            var lineSeparator = ((char) 0x2028).ToString();
            var paragraphSeparator = ((char) 0x2029).ToString();

            return source.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty)
                .Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        /// <summary>
        /// Removes Trailing Spaces
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveTrailingSpaces(this string value) => value.TrimStart().TrimEnd();

        /// <summary>
        /// Gets words from the source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <param name="wordDelimiter"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string[] GetWords(this string source, int count = -1, string[] wordDelimiter = null,
            StringSplitOptions options = StringSplitOptions.None)
        {
            if (string.IsNullOrEmpty(source)) return new string[] { };

            if (count < 0)
                return source.Split(wordDelimiter, options);

            var words = source.Split(wordDelimiter, count + 1, options);
            if (words.Length <= count)
                return words; // not so many words found

            // remove last "word" since that contains the rest of the string
            Array.Resize(ref words, words.Length - 1);

            return words;
        }

        /// <summary>
        /// Removes special characters that are often generated by word.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CleanWordFormatting(this string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                return source.Replace('\u2013', '-')
                    .Replace('\u2013', '-')
                    .Replace('\u2014', '-')
                    .Replace('\u2015', '-')
                    .Replace('\u2017', '_')
                    .Replace('\u2018', '\'')
                    .Replace('\u2019', '\'')
                    .Replace('\u201a', ',')
                    .Replace('\u201b', '\'')
                    .Replace('\u201c', '\"')
                    .Replace('\u201d', '\"')
                    .Replace('\u201e', '\"')
                    .Replace("\u2026", "...")
                    .Replace('\u2032', '\'')
                    .Replace('\u2033', '\"');
            }
            return source;
        }

        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one".
        /// </summary>
        /// <param name="source">String to make URL Friendly</param>
        public static string UrlFriendly(this string source)
        {
            if (source == null) return "";

            const int maxlen = 250;
            var len = source.Length;
            var prevdash = false;
            var sb = new StringBuilder(len);

            for (int i = 0; i < len; i++)
            {
                var c = source[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char) (c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                         c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int) c >= 128)
                {
                    var prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (i == maxlen) break;
            }

            return prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
        }

        /// <summary>
        /// Remaps International Char to Ascii
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string RemapInternationalCharToAscii(char c)
        {
            var s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            if ("èéêëę".Contains(s))
            {
                return "e";
            }
            if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            if ("żźž".Contains(s))
            {
                return "z";
            }
            if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            if ("ñń".Contains(s))
            {
                return "n";
            }
            if ("ýÿ".Contains(s))
            {
                return "y";
            }
            if ("ğĝ".Contains(s))
            {
                return "g";
            }
            if (c == 'ř')
            {
                return "r";
            }
            if (c == 'ł')
            {
                return "l";
            }
            if (c == 'đ')
            {
                return "d";
            }
            if (c == 'ß')
            {
                return "ss";
            }
            if (c == 'Þ')
            {
                return "th";
            }
            if (c == 'ĥ')
            {
                return "h";
            }
            if (c == 'ĵ')
            {
                return "j";
            }
            return "";
        }

        /// <summary>
        /// Checks if source is a valid URL
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsValidUrl(this string source) => Uri.TryCreate(source, UriKind.Absolute, out Uri uri)
                                                             && (uri.Scheme == Uri.UriSchemeHttp
                                                                 || uri.Scheme == Uri.UriSchemeHttps
                                                                 || uri.Scheme == Uri.UriSchemeFtp
                                                                 || uri.Scheme == Uri.UriSchemeMailto);

        /// <summary>
        /// Generates a list from a string based on the delimiter. Replaces line breaks and tabs with delimiter.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<string> GetList(this string source, char delimiter = ',')
        {
            if(string.IsNullOrEmpty(source))
                return new List<string>();

            var charString = delimiter.ToString();

            var cleanString = Regex.Replace(source, @"\r\n?|\n", charString);
            cleanString = cleanString.Replace("\t", charString);

            var stringList = cleanString.Split(delimiter).Select(x => x.Trim()).Distinct().ToList();
            return stringList;
        }
    }
}