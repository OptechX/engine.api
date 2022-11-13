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
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == value)
                    return (T)field.GetValue(null);
            }
        }
        throw new ArgumentException($"unknow value: {value}");
    }
}