namespace SHJ.Toolkits.Strings;


/// <summary>
/// Extension methods for String class.
/// </summary>
public static class LocalicationStringExtensions
{
    public const char ArabicYeChar = (char)1610;
    public const char PersianYeChar = (char)1740;
    public const char ArabicKeChar = (char)1603;
    public const char PersianKeChar = (char)1705;


    /// <summary>
    ///  Separate three digits
    /// </summary>
    /// <param name="value">123456</param>
    /// <returns>"123,456"</returns>
    public static string ToNumeric(this int value)
    {
        return value.ToString("N0"); //"123,456"
    }
    public static decimal ToDecimal(this string value)
    {
        return Convert.ToDecimal(value);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="ignoreWhiteSpace"></param>
    /// <returns></returns>
    public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
    {
        return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt(this string value)
    {
        return Convert.ToInt32(value);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToNumeric(this decimal value)
    {
        return value.ToString("N0");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToCurrency(this int value)
    {
        //fa-IR => current culture currency symbol => ریال
        //123456 => "123,123ریال"
        return value.ToString("C0");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToCurrency(this decimal value)
    {
        return value.ToString("C0");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string En2Fa(this string str)
    {
        return str.Replace("0", "۰")
            .Replace("1", "۱")
            .Replace("2", "۲")
            .Replace("3", "۳")
            .Replace("4", "۴")
            .Replace("5", "۵")
            .Replace("6", "۶")
            .Replace("7", "۷")
            .Replace("8", "۸")
            .Replace("9", "۹");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Fa2En(this string str)
    {
        return str.Replace("۰", "0")
            .Replace("۱", "1")
            .Replace("۲", "2")
            .Replace("۳", "3")
            .Replace("۴", "4")
            .Replace("۵", "5")
            .Replace("۶", "6")
            .Replace("۷", "7")
            .Replace("۸", "8")
            .Replace("۹", "9")
            //iphone numeric
            .Replace("٠", "0")
            .Replace("١", "1")
            .Replace("٢", "2")
            .Replace("٣", "3")
            .Replace("٤", "4")
            .Replace("٥", "5")
            .Replace("٦", "6")
            .Replace("٧", "7")
            .Replace("٨", "8")
            .Replace("٩", "9");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FixPersianChars(this string str)
    {
        return str.Replace("ﮎ", "ک")
            .Replace("ﮏ", "ک")
            .Replace("ﮐ", "ک")
            .Replace("ﮑ", "ک")
            .Replace("ك", "ک")
            .Replace("ي", "ی")
            .Replace(" ", " ")
            .Replace("‌", " ")
            .Replace("ھ", "ه");//.Replace("ئ", "ی");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string CleanString(this string str)
    {
        return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string NullIfEmpty(this string str)
    {
        return str?.Length == 0 ? null : str;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ApplyCorrectYeKe(this object data)
    {
        return data == null ? null : ApplyCorrectYeKe(data.ToString());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ApplyCorrectYeKe(this string data)
    {
        return string.IsNullOrWhiteSpace(data) ?
                    string.Empty :
                    data.Replace(ArabicYeChar, PersianYeChar).Replace(ArabicKeChar, PersianKeChar).Trim();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="replacement"></param>
    /// <returns></returns>
    public static long ToSafeLong(this string input, long replacement = long.MinValue) =>
         long.TryParse(input, out long result) ? result : replacement;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static long? ToSafeNullableLong(this string input) =>
        long.TryParse(input, out long result) ? result : null;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="replacement"></param>
    /// <returns></returns>

    public static int ToSafeInt(this string input, int replacement = int.MinValue) =>
     int.TryParse(input, out int result) ? result : replacement;
    public static int? ToSafeNullableInt(this string input) =>
        int.TryParse(input, out int result) ? result : null;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ToStringOrEmpty(this string? input) => input ?? string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ToUnderscoreCase(this string input) =>
        string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();

}
