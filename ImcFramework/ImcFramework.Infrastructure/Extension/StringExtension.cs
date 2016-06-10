using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ImcFramework.Infrastructure
{
    public static class StringExtension
    {
        static StringExtension()
        {
        }

        #region Convert

        /// <summary>
        /// 转换为Int32
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>Int32</returns>
        public static Int32 ToInt32(this string str)
        {
            return int.Parse(str);
        }

        /// <summary>
        /// 转换为可为空的32位整型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>Nullale Int32</returns>
        public static Int32? ToNullableInt32(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            return str.ToInt32();
        }

        /// <summary>
        /// 转换为Int64
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>Int64</returns>
        public static Int64 ToInt64(this string str)
        {
            return long.Parse(str);
        }

        /// <summary>
        /// 转换为可为空的64位整型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>Nullale Int64</returns>
        public static Int64? ToNullableInt64(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            return str.ToInt64();
        }



        public static DateTime? ToNullableDateTime(this string str)
        {
            if (str.IsNullOrEmpty()) return null;
            return str.ToDateTime();
        }

        public static Double ToDouble(this string str)
        {
            return double.Parse(str);
        }

        public static Double? ToNullableDouble(this string str)
        {
            if (str.IsNullOrEmpty()) return null;
            return str.ToDouble();
        }

        public static Decimal ToDecimal(this string str)
        {
            return decimal.Parse(str);
        }

        public static Decimal? ToNullableDecimal(this string str)
        {
            if (str.IsNullOrEmpty()) return null;
            return str.ToDecimal();
        }

        public static T ToType<T>(this string str)
        {
            var val = Convert.ChangeType(str, typeof(T));
            return (T)val;
        }

        public static string ToUnicodeString(this string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append("0x" + Convert.ToString(char.ConvertToUtf32(c.ToString(), 0), 16).ToUpper().PadLeft(4, '0'));
            }
            return sb.ToString();
        }
        public static string FromUnicodeString(this string str)
        {
            return Regex.Replace(str, @"0x[\w]{4}", delegate(Match m) { return char.ConvertFromUtf32(Convert.ToInt32(m.Value, 16)); }, RegexOptions.IgnoreCase);
        }
        #endregion

        #region RegexValidate

        public static bool IsValidEmail(this string str)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(str);
        }

        #endregion

        #region Basic
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        #endregion
        
    }
}
