using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Infrastructure
{
    public static class DateTimeExtension
    {
        private static DateTime m_minValue = new DateTime(1900, 1, 1);
        private static DateTime m_maxValue = new DateTime(3000, 12, 31);

        public const string SHORT_FORMAT_STRING = "yyyy-MM-dd";
        public const string LONG_FROMAT_STRING = "yyyy-MM-dd HH:mm";
        public const string FORMAT_yyyy_MM_dd_HH_mm_ss = "yyyy-MM-dd HH:mm:ss";

        public static DateTime MinValue
        {
            get
            {
                return m_minValue;
            }
        }

        public static DateTime MaxValue
        {
            get
            {
                return m_maxValue;
            }
        }

        public static DateTime ToDateTime(this string str)
        {
            return DateTime.Parse(str);
        }

        #region 太平洋时间

        public static DateTime ToPacificStandardTime(this DateTime dt)
        {
            var pstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            return System.TimeZoneInfo.ConvertTime(dt, pstTimeZoneInfo);
        }

        public static DateTime GetNowPacificStandardTime()
        {
            var localTimeNow = System.DateTime.Now;
            var pstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var dt = System.TimeZoneInfo.ConvertTime(localTimeNow, pstTimeZoneInfo);
            Console.WriteLine(dt);
            return dt;
        }

        #endregion

        #region ISO8601
        public static string ToISO8601DateFormat(this DateTime dt)
        {
            //Console.WriteLine("dt2:" + dt.ToString("yyyy-MM-ddTHH:mm:ssK"));
            return dt.ToString("yyyy-MM-ddTHH:mm:ssK");
        }

        public static string UtcNowToISO8601DateFormat()
        {
            return DateTime.UtcNow.ToISO8601DateFormat();
        }

        #endregion
    }
}
