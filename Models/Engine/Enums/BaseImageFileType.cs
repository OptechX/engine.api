using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum BaseImageFileType
    {
        [EnumMember(Value = "WIM")] WIM,
        [EnumMember(Value = "ISO")] ISO,
        [EnumMember(Value = "ZIP")] ZIP,
        [EnumMember(Value = "SWM")] SWM
    }
}

