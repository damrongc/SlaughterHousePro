using System;

namespace SlaughterHouseLib
{
    public static class MyExtension
    {

        public static double Power(this double a, double b)
        {
            return System.Math.Pow(a, b);
        }

        public static double ToDouble(this string a)
        {
            return double.Parse(a);
        }
        public static Int16 ToInt16(this string a)
        {
            return Int16.Parse(a);
        }
        public static Int32 ToInt32(this string a)
        {
            return Int32.Parse(a);
        }

        public static long ToLong(this string a)
        {
            return long.Parse(a);
        }

        public static decimal ToDecimal(this string a)
        {
            return decimal.Parse(a);
        }

        /// <summary>
        /// format double to #.##
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ToFormat2Decimal(this decimal a)
        {
            return String.Format("{0: #,##0.00}", a);
        }

        public static string ToFormat2Double(this double a)
        {
            return String.Format("{0: #,##0.00}", a);
        }
        public static string ToDateFormat(this DateTime a)
        {
            return a.ToString("yyyy.MM.dd");
        }
    }
}
