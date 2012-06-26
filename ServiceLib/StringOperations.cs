using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ServiceLib
{
    public static class StringOperations
    {
        private static Dictionary<string, string> iso = new Dictionary<string, string>(); //ISO 9-95

        /// <summary>
        /// Will transform "some $ugly ###url wit[]h spaces" into "some-ugly-url-with-spaces"
        /// </summary>
        /// Example slug
        ///     string title = @"A bunch of ()/*++\'#@$&*^!%     invalid URL characters  ";
        ///     return title.Slugify();
        /// Outputs
        ///     a-bunch-of-invalid-url-characters
        public static string Slugify(this string phrase, int maxLength = 64)
        {
            string str = phrase.ToLower();

            // invalid chars, make into spaces
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces/hyphens into one space       
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();
            // cut and trim it
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            // hyphens
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }

        /// <summary>
        /// Transliteration string ru->en
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToTranslit(this string phrase)
        {
            string result = phrase;
            foreach (var element in iso)
            {
                result = result.Replace(element.Key, element.Value);
            }
            return result;
        }

        //public static string FromTranslit(this string phrase)
        //{
        //    string result = phrase;
        //    foreach (var element in iso)
        //    {
        //        result = result.Replace(element.Value, element.Key);
        //    }
        //    return result;
        //}

        /// <summary>
        /// Split phrase to string array
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="delimiters">char[] delimiters</param>
        /// <returns>string[]</returns>
        public static string[] SplitToArray(this string phrase, char[] delimiters = null)
        {
            string[] result = null;
            if (delimiters == null)
            {
                delimiters = new char[]{',', ';', '?'};
            }
            result = phrase.Split(delimiters);
            return result;
        }

        /// <summary>
        /// Fast and easy hash function for string
        /// Do not have platform dependency
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>ulong hash</returns>
        public static ulong GetHashString(this string phrase)
        {
            ulong hash = 0;
            unchecked
            {
                for (int i = 0; i < phrase.Length; i++)
                {
                    hash = hash * 97 + phrase[i];
                }
            }
            
            return hash;
        }

        public static string ArrayToString(this string[] array, string delimiter = ",")
        {
            string result = string.Join(delimiter, array);
            return result;
        }

        public static string EnumerableToString(this IEnumerable<string> enumerable, string delimiter = ",")
        {
            string result = string.Join(delimiter, enumerable);
            return result;
        }



        static StringOperations()
        {
            FillTranslitDictionary();
        }

        private static void FillTranslitDictionary()
        {
            iso.Add("Є", "YE");
            iso.Add("І", "I");
            iso.Add("Ѓ", "G");
            iso.Add("і", "i");
            iso.Add("№", "#");
            iso.Add("є", "ye");
            iso.Add("ѓ", "g");
            iso.Add("А", "A");
            iso.Add("Б", "B");
            iso.Add("В", "V");
            iso.Add("Г", "G");
            iso.Add("Д", "D");
            iso.Add("Е", "E");
            iso.Add("Ё", "E");
            iso.Add("Ж", "ZH");
            iso.Add("З", "Z");
            iso.Add("И", "I");
            iso.Add("Й", "J");
            iso.Add("К", "K");
            iso.Add("Л", "L");
            iso.Add("М", "M");
            iso.Add("Н", "N");
            iso.Add("О", "O");
            iso.Add("П", "P");
            iso.Add("Р", "R");
            iso.Add("С", "S");
            iso.Add("Т", "T");
            iso.Add("У", "U");
            iso.Add("Ф", "F");
            iso.Add("Х", "H");
            iso.Add("Ц", "C");
            iso.Add("Ч", "CH");
            iso.Add("Ш", "SH");
            iso.Add("Щ", "SHH");
            iso.Add("Ъ", "'");
            iso.Add("Ы", "Y");
            iso.Add("Ь", "");
            iso.Add("Э", "E");
            iso.Add("Ю", "YU");
            iso.Add("Я", "YA");
            iso.Add("а", "a");
            iso.Add("б", "b");
            iso.Add("в", "v");
            iso.Add("г", "g");
            iso.Add("д", "d");
            iso.Add("е", "e");
            iso.Add("ё", "e");
            iso.Add("ж", "zh");
            iso.Add("з", "z");
            iso.Add("и", "i");
            iso.Add("й", "j");
            iso.Add("к", "k");
            iso.Add("л", "l");
            iso.Add("м", "m");
            iso.Add("н", "n");
            iso.Add("о", "o");
            iso.Add("п", "p");
            iso.Add("р", "r");
            iso.Add("с", "s");
            iso.Add("т", "t");
            iso.Add("у", "u");
            iso.Add("ф", "f");
            iso.Add("х", "h");
            iso.Add("ц", "c");
            iso.Add("ч", "ch");
            iso.Add("ш", "sh");
            iso.Add("щ", "shh");
            iso.Add("ъ", "");
            iso.Add("ы", "y");
            iso.Add("ь", "");
            iso.Add("э", "e");
            iso.Add("ю", "yu");
            iso.Add("я", "ya");
            iso.Add("«", "");
            iso.Add("»", "");
            iso.Add("—", "-");
        }
    }
}

