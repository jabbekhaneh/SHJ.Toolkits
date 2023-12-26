using System.ComponentModel;

namespace System;

public static class EnumExtensions
{
    /// <summary>
    /// This method is used to get the description of an attribute from enum if it has [Description].
    /// </summary>
    /// <param name="enumValue">Amount for which explanations are to be received</param>
    /// <returns>The text inside [Description] if it exists and otherwise the title of enums is sent</returns>
    public static string GetEnumDescription(this Enum enumValue)
    {
        var memberInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        var description = attributes != null ? ((DescriptionAttribute)attributes.FirstOrDefault()).Description : enumValue.ToString();
        return description;
    }


    public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new NotSupportedException();

        return Enum.GetValues(input.GetType()).Cast<T>();
    }

    public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new NotSupportedException();

        foreach (var value in Enum.GetValues(input.GetType()))
            if ((input as Enum).HasFlag(value as Enum))
                yield return (T)value;
    }


}

