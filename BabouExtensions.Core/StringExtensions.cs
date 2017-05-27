using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BabouExtensions.Core
{
    public static class StringExtensions
    {
        /// <summary>
        /// Attempts to convert a string into proper title case.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string source)
        {
            var tokens = source.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1).ToLower();
            }

            return string.Join(" ", tokens);
        }

        /// <summary>
        /// Uppercases the first leter of a string.
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

        public static string ToStringOrDefault<T>(this T? nullable, string defaultValue) where T : struct
        {
            return nullable?.ToString() ?? defaultValue;
        }

        public static string ToStringOrDefault<T>(this T? nullable, string format, string defaultValue) where T : struct, IFormattable
        {
            return nullable?.ToString(format, CultureInfo.CurrentCulture) ?? defaultValue;
        }

        /// <summary>
        /// Goes through the string and addes a space between capital letters, excluding the first character.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddSpacesToSentence(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            for (var i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public static string CleanPhone(this string phone)
        {
            var digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(phone, "");
        }

        public static string StripSpacesAndNonAlphaNumeric(this string input)
        {
            var regex = new Regex(@"[^A-Za-z0-9]+");
            return regex.Replace(input, string.Empty);
        }

        public static string StripHtml(this string input)
        {
            var tagsExpression = new Regex(@"<[^>]*>");
            return tagsExpression.Replace(input, " ");
        }

        public static string RemoveLineEndings(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            var lineSeparator = ((char)0x2028).ToString();
            var paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        public static string RemoveTrailingSpaces(this string value)
        {
            return value.TrimStart().TrimEnd();
        }

        public static string[] GetWords(this string input, int count = -1, string[] wordDelimiter = null, StringSplitOptions options = StringSplitOptions.None)
        {
            if (string.IsNullOrEmpty(input)) return new string[] { };

            if (count < 0)
                return input.Split(wordDelimiter, options);

            var words = input.Split(wordDelimiter, count + 1, options);
            if (words.Length <= count)
                return words;   // not so many words found

            // remove last "word" since that contains the rest of the string
            Array.Resize(ref words, words.Length - 1);

            return words;
        }

        /// <summary>
        /// Removes special characters that are often generated by word.
        /// </summary>
        /// <param name="wordText"></param>
        /// <returns></returns>
        public static string CleanWordFormatting(this string wordText)
        {
            if (!string.IsNullOrEmpty(wordText))
            {
                return wordText.Replace('\u2013', '-')
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
            return wordText;
        }

        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one".
        /// </summary>
        /// <param name="title">String to make URL Friendly</param>
        public static string URLFriendly(this string title)
        {
            if (title == null) return "";

            const int maxlen = 250;
            var len = title.Length;
            var prevdash = false;
            var sb = new StringBuilder(len);

            for (int i = 0; i < len; i++)
            {
                var c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
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
                else if ((int)c >= 128)
                {
                    var prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (i == maxlen) break;
            }

            return prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
        }

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

        public static bool IsValidUrl(this string urlString)
        {
            return Uri.TryCreate(urlString, UriKind.Absolute, out Uri uri);
        }
    }
}