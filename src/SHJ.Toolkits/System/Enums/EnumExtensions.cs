using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
    public static T ToEnum<T>(this string value)
    {
        try
        {
            return (T)System.Enum.Parse(typeof(T), value);
        }
        catch
        {
            return default(T);
        }
    }
    public static T ToEnum<T>(this byte value)
    {
        try
        {
            return (T)System.Enum.Parse(typeof(T), value.ToString());
        }
        catch
        {
            return default(T);
        }
    }
    public static string GetDisplayName(this System.Enum enumValue)
    {
        try
        {
            return enumValue.GetType()
                           .GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .GetName();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static string ToDescription(this System.Enum value)
    {
        try
        {


            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).
                GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        catch
        {
            return "";
        }
    }

    public static string GetName<t>(this System.Enum enumValue)
    {

        return System.Enum.GetName(typeof(t), enumValue);
    }


    public static IEnumerable<SelectListItem> ToSelectListDescription(this System.Enum enumValue, bool numericValue = false)
    {
        var enumItems = System.Enum.GetValues(enumValue.GetType()).OfType<System.Enum>().ToList();
        var list = new List<SelectListItem>();
        if (numericValue)
            list.AddRange(enumItems.Select(item => new SelectListItem() { Text = item.ToDescription(), Value = Convert.ToInt16(item).ToString() }));
        else
        {
            list.AddRange(enumItems.Select(item => new SelectListItem() { Text = item.ToDescription(), Value = item.ToString() }));
        }
        return list;
    }


    public static List<SelectListItem> ToSelectList(this System.Enum enumValue, bool numericValue = false, bool selected = false)
    {
        var enumItems = System.Enum.GetValues(enumValue.GetType()).OfType<System.Enum>().ToList();
        var list = new List<SelectListItem>();
        if (numericValue)
            list.AddRange(enumItems.Select(item => new SelectListItem()
            {
                Text = item.GetDisplayName(),
                Value = Convert.ToInt16(item).ToString(),
                Selected = item.ToString() == enumValue.ToString() && selected
            }));
        else
        {
            list.AddRange(enumItems.Select(item => new SelectListItem()
            {
                Text = item.GetDisplayName(),
                Value = item.ToString(),
                Selected = item.ToString() == enumValue.ToString() && selected
            }));
        }
        return list;
    }

    public static TAttribute GetAttribute<TAttribute>(this System.Enum value) where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = System.Enum.GetName(type, value);
        return type.GetField(name) // I prefer to get attributes this way
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .SingleOrDefault();
    }


}

