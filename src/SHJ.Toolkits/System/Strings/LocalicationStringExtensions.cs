namespace System;


/// <summary>
/// Extension methods for String class.
/// </summary>
public static class LocalicationStringExtensions
{

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
    /// <param name="str"></param>
    /// <returns></returns>
    public static string NullIfEmpty(this string str)
    {
        return str?.Length == 0 ? null : str;
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
