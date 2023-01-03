using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum ApplicationCategory
    {
        [EnumMember(Value = "Productivity")] Productivity,
        [EnumMember(Value = "Microsoft")] Microsoft,
        [EnumMember(Value = "Utility")] Utility,
        [EnumMember(Value = "Developer Tools")] Developer_Tools,
        [EnumMember(Value = "Games")] Games,
        [EnumMember(Value = "Photo & Design")] Photo_Design,
        [EnumMember(Value = "Entertainment")] Entertainment,
        [EnumMember(Value = "Security")] Security,
        [EnumMember(Value = "Education")] Education,
        [EnumMember(Value = "Internet")] Internet,
        [EnumMember(Value = "Lifestyle")] Lifestyle
    }
}

