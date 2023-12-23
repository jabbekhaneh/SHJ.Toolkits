using SHJ.Toolkits.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SHJ.Toolkits.Enums;

public static class EnumExtensions
{
    /// <summary>
    /// برای دریافت توضیحات یک ویژگی از enum اگر [Description] داشته باشد از این متد استفاده می‌شود.
    /// </summary>
    /// <param name="enumValue">مقداری که قرار است توضحیات آن دریافت شود</param>
    /// <returns>متن داخل [Description] در صورتی که وجود داشته باشد و در غیراین صورت عنوان enums ارسال شده</returns>
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

