using System;
using System.Runtime.Serialization;

namespace Stackoverflow.Answers.Helpers;

public static class EnumExtensions
{
    public static T GetValueFromEnumMember<T>(string value) where T : Enum
    {
        var type = typeof(T);
        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(EnumMemberAttribute)) as EnumMemberAttribute;
            if (attribute != null)
            {
                if (attribute.Value == value)
#pragma warning disable CS8600 // Possible null reference return.
#pragma warning disable CS8603 // Possible null reference return.
                    return (T)field.GetValue(null);
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Possible null reference return.
            }
            else
            {
                if (field.Name == value)
#pragma warning disable CS8600 // Possible null reference return.
#pragma warning disable CS8603 // Possible null reference return.
                    return (T)field.GetValue(null);
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8600 // Possible null reference return.
            }
        }
        throw new ArgumentException($"unknow value: {value}");
    }
}