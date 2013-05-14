namespace Telerik.ILS.Common
{
    // ERROR with summary in sand castle ... :>?
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// File extention class
    /// </summary>

    public static class StringExtensions
    {
        /// <summary>
        /// Converts an inputed string to coresponding Hash representation
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <returns>Hash representation</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        ///  Converts an inputed string to coresponding Boolean - TRUE representation
        /// </summary>
        /// <remarks>Returns True if it meets the predifened True Values</remarks>
        /// <remarks>Returns False if it does not meets the predifened True Values</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>True or False</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        ///  Converts an inputed string to coresponding 16-bit integer representation
        /// </summary>
        /// <remarks>If the string can be parsed, then it returns a valid value</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>Value in 16-bit integer format or Exception</returns>
        /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        ///  Converts an inputed string to coresponding 32-bit integer representation
        /// </summary>
        /// <remarks>If the string can be parsed, then it returns a valid value</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>Value in 32-bit integer format or Exception</returns>
        /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        ///  Converts an inputed string to coresponding 64-bit integer representation
        /// </summary>
        /// <remarks>If the string can be parsed, then it returns a valid value</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>Value in 64-bit integer format or Exception</returns>
        /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        ///  Converts an inputed string to a DateTime representation
        /// </summary>
        /// <remarks>If the string can be parsed, then it returns a valid DateTime</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>DateTime or Exception</returns>
        /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
        /// <exception cref="NotSupportedException">If the converted DateTime is not supported, sneds this Exception</exception>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        ///  Makes the first letter of a string to be a Capitalized
        /// </summary>
        /// <remarks>If the string is not empty, then it can capitalize</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>Inputed string or Inputed string with first letter Capitalized</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        ///  Gets a string, between two strings
        /// </summary>
        /// <remarks>If the 'start' and 'end' strings are not found, returns empty</remarks>
        /// <param name="input">Inputed string</param>
        /// <param name="startString">String to start looking from</param>
        /// <param name="endString">String to stop looking to</param>
        /// <param name="startFrom">Sets the scope of the Inputed string from where to start</param>
        /// <returns>Empty string or requested string</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        ///  Converts a string's letters from Cyrillic to their Latin representation
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <remarks>All Capital letters are also converted to Capital letters</remarks>
        /// <returns>Converted Letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        ///  Converts a string's letters from Latin to their Cyrillic representation
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <remarks>All Capital letters are also converted to Capital letters</remarks>
        /// <returns>Converted Letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        ///  Converts the given Username to a one, containing only valid symbols
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <remarks>Username is converted to Latin letters
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        /// </remarks>
        /// <remarks>Uses Regex</remarks>
        /// <example>
        /// <code>
        /// return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        /// </code>
        /// </example>
        /// <returns>Converted Username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        ///  Converts the given file name to have a Valid and Latin name
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <remarks>Username is converted to Latin letters
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        /// </remarks>
        /// <remarks>Uses Regex</remarks>
        /// <example>
        /// <code>
        /// return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        /// </code>
        /// </example>
        /// <returns>Converted FileName</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        ///  Gets the first characters from a string
        /// </summary>
        /// <param name="input">Inputed string</param>
        /// <param name="charsCount">How many chars to get</param>
        /// <remarks>Returns the Minimum amount of characters
        /// <returns>Requested amount of characters in a String format</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        ///  Gets the file extention from given name
        /// </summary>
        /// <param name="fileName">Inputed fileName</param>
        /// <remarks>If the file is empty or Null, returns Empty string</remarks>
        /// <remarks>If the file's name is unpropperly labeledm returns empty String</remarks>
        /// <example>
        /// <code>
        /// string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        /// if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        /// {
        ///     return string.Empty;
        /// }
        /// </code>
        /// </example>
        /// <returns>FileName.Extention as string or Empty string</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        ///  Converts the extention to content type
        /// </summary>
        /// <param name="fileExtension">Inputed fileExtention</param>
        /// <returns>"application/octet-stream" or Content type as String</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }
        /// <summary>
        ///  Converts an inputed string to coresponding Byte Array representation
        /// </summary>
        /// <remarks>I have no idea how Buffer.BlockCopy works :D</remarks>
        /// <param name="input">Inputed string</param>
        /// <returns>Corresponding Byte Array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
