using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BabouExtensions
{
    /// <summary>
    /// String Extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into proper title case.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="lowerCaseWords">Words to lowercase</param>
        /// <returns></returns>
        public static string ToTitleCase(this string source, string[] lowerCaseWords = null)
        {
            var result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());

            if (lowerCaseWords != null)
            {
                const RegexOptions options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
                var lowerWordsSplit = string.Join("|", lowerCaseWords);
                result = Regex.Replace(result, $@"({lowerWordsSplit})", m => m.Value.ToLower(), options);
            }

            return result;
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
        /// <exception cref="System.ArgumentException">If T is not an Enum</exception>
        public static T GetEnumValueFromDescription<T>(this string source)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            var fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                    (f, a) => new { Field = f, Att = a })
                .SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == source);
            return (T)field?.Field.GetRawConstantValue();
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
        /// <param name="replacementString">What to replace the HTML with. Defaults to an empty space.</param>
        /// <returns></returns>
        public static string StripHtml(this string source, string replacementString = " ") => new Regex(@"<[^>]*>").Replace(source, replacementString);

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
            var lineSeparator = ((char)0x2028).ToString();
            var paragraphSeparator = ((char)0x2029).ToString();

            return source.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty)
                .Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        /// <summary>
        /// Removes tabs, line breaks, extra spaces, etc. Trims string as well.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="additionalReplacements"></param>
        /// <returns></returns>
        public static string CleanString(this string source, string[] additionalReplacements = null)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            source = Regex.Replace(source, @"\r\n?|\n|\t", string.Empty);
            source = Regex.Replace(source, @"(<br \/>|<br\/>|<\/ br>|<\/br>)", string.Empty);
            source = Regex.Replace(source, @"(<p>)|(<\/p>)", string.Empty);
            source = Regex.Replace(source, @"[ ]{2,}", string.Empty);
            if (additionalReplacements != null)
                source = additionalReplacements.Aggregate(source, (current, word) => current.Replace(word, string.Empty));

            source = source.Trim();

            return source;
        }

        /// <summary>
        /// Removes Trailing Spaces
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveTrailingSpaces(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            return source.TrimStart().TrimEnd();
        }

        /// <summary>
        /// Gets words from the source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <param name="wordDelimiter"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string[] GetWords(this string source, int count = -1, string[] wordDelimiter = null, StringSplitOptions options = StringSplitOptions.None)
        {
            if (string.IsNullOrEmpty(source))
                return new string[] { };

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
        /// <param name="maxLength">Maximum length of the url</param>
        public static string UrlFriendly(this string source, int maxLength)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var len = source.Length;
            var prevdash = false;
            var sb = new StringBuilder(len);

            for (var i = 0; i < len; i++)
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
                else if (c >= 128)
                {
                    var prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length)
                        prevdash = false;
                }
                if (i == maxLength)
                    break;
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
        public static bool IsValidUrl(this string source) => Uri.TryCreate(source, UriKind.Absolute, out var uri)
                                                             && (uri.Scheme == Uri.UriSchemeHttp
                                                                 || uri.Scheme == Uri.UriSchemeHttps
                                                                 || uri.Scheme == Uri.UriSchemeFtp
                                                                 || uri.Scheme == Uri.UriSchemeMailto);

        /// <summary>
        /// Generates a list from a string based on the delimiter.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="delimiter"></param>
        /// <param name="replaceLineBreaksAndTabs">Replaces line breaks and tabs with delimiter.</param>
        /// <returns></returns>
        public static List<string> GetList(this string source, char delimiter = ',', bool replaceLineBreaksAndTabs = true)
        {
            if (string.IsNullOrEmpty(source))
                return new List<string>();

            var charString = delimiter.ToString();

            var cleanString = source;

            if (replaceLineBreaksAndTabs)
            {
                cleanString = Regex.Replace(source, @"\r\n?|\n", charString);
                cleanString = cleanString.Replace("\t", charString);
            }

            var stringList = cleanString.Split(delimiter).Select(x => x.Trim()).Distinct().ToList();
            return stringList;
        }

        /// <summary>
        /// Generates a list from a string based on the delimiter. Replaces line breaks and tabs with delimiter.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="delimiter">Character to split on</param>
        /// <param name="sourceList">If source is empty, returns an empty list</param>
        /// <returns>Either an empty list if source is empty or a list of strings.</returns>
        public static bool TryGetList(this string source, char delimiter, out List<string> sourceList)
        {
            if (string.IsNullOrEmpty(source))
            {
                sourceList = new List<string>();
                return false;
            }

            var charString = delimiter.ToString();

            var cleanString = Regex.Replace(source, @"\r\n?|\n", charString);
            cleanString = cleanString.Replace("\t", charString);

            var stringList = cleanString.Split(delimiter).Select(x => x.Trim()).Distinct().ToList();
            sourceList = stringList;
            return true;
        }

        /// <summary>
        /// Indicates whether the specified string is null or an empty string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            return System.Net.WebUtility.HtmlDecode(source);
        }

        /// <summary>
        /// Converts a string into an HTML-encoded string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            return System.Net.WebUtility.HtmlEncode(source);
        }

        /// <summary>
        /// Determines if a string is a valid date. Returns dateTime as a date or null.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDate(this string source, out DateTime? dateTime)
        {
            if (!string.IsNullOrEmpty(source) && System.DateTime.TryParse(source, out var realDateTime))
            {
                dateTime = realDateTime;
                return true;
            }
            else
            {
                dateTime = null;
                return false;
            }
        }

        /// <summary>
        /// Encrypts a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToEncrypt">String that must be encrypted.</param>
        /// <param name="key">Encryption Key.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string stringToEncrypt, string key)
        {
            if (string.IsNullOrEmpty(stringToEncrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            var cspp = new CspParameters
            {
                KeyContainerName = key
            };

            var rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true
            };

            var bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(stringToEncrypt), true);

            return BitConverter.ToString(bytes);
        }

        /// <summary>
        /// Decrypts a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToDecrypt">String that must be decrypted.</param>
        /// <param name="key">The Decryption Key.</param>
        /// <returns>The decrypted string or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string stringToDecrypt, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            var cspp = new CspParameters
            {
                KeyContainerName = key
            };

            var rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            var decryptArray = stringToDecrypt.Split(new[] { "-" }, StringSplitOptions.None);
            var decryptByteArray = Array.ConvertAll(decryptArray, (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));

            var bytes = rsa.Decrypt(decryptByteArray, true);

            result = Encoding.UTF8.GetString(bytes);

            return result;
        }

        /// <summary>
        /// Tries to get a URL from a string. Also uses IsValidUrl extension.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool TryGetUrl(this string source, out string url)
        {
            const string urlRegex = @"(?:(?:https?):\/\/|www\.|ftp\.)(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[-A-Z0-9+&@#\/%=~_|$?!:,.])*(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[A-Z0-9+&@#\/%=~_|$])";

            if (Regex.IsMatch(source, urlRegex, RegexOptions.IgnoreCase))
            {
                var tempUrl = Regex.Match(source, urlRegex, RegexOptions.IgnoreCase).Value;
                if (tempUrl.IsValidUrl())
                {
                    url = tempUrl;
                    return true;
                }
            }
            url = string.Empty;
            return false;
        }

        /// <summary>
        /// Returns null or date in the format provided. Default format is yyyy-MM-dd
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">The format of the date time string.</param>
        /// <returns></returns>
        public static string TryGetDate(this string source, string format = "yyyy-MM-dd")
        {
            return source.IsDate(out var releaseDateTime) ? releaseDateTime?.ToString(format) : null;
        }

        /// <summary>
        /// Returns a double or null value
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double? TryGetDouble(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            if (double.TryParse(source, out var rating))
                return rating;

            return null;

        }
    }
}