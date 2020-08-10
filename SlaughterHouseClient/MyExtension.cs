using System;
public static class MyExtension
{
    public static double Power(this double a, double b)
    {
        return System.Math.Pow(a, b);
    }
    public static double ToDouble(this string a)
    {
        return double.Parse(a.Replace(" ", "").Trim());
    }
    public static short ToInt16(this string a)
    {
        return short.Parse(a.Replace(" ", "").Trim());
    }
    public static int ToInt32(this string a)
    {
        return int.Parse(a.Replace(" ", "").Trim());
    }
    public static long ToLong(this string a)
    {
        return long.Parse(a.Replace(" ", "").Trim());
    }
    public static decimal ToDecimal(this string a)
    {
        return decimal.Parse(a.Replace(" ", "").Trim());
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
    public static string ToFormatNoDecimal(this decimal a)
    {
        return string.Format("{0: #,##0}", a);
    }
    public static string ToFormatNoDouble(this double a)
    {
        return string.Format("{0: #,##0}", a);
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
