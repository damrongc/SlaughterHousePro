using System;


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
    public static short ToInt16(this string a)
    {
        return short.Parse(a);
    }
    public static int ToInt32(this string a)
    {
        return int.Parse(a);
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
        return string.Format("{0: #,##0.00}", a);
    }

    public static string ToFormat2Double(this double a)
    {
        return string.Format("{0: #,##0.00}", a);
    }
    public static string ToComma(this int a)
    {
        return string.Format("{0: #,##0}", a);
    }
    public static string ToDateFormat(this DateTime a)
    {
        return a.ToString("yyyy.MM.dd");
    }
}
