using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum ImageOutputFormat
    {
        [EnumMember(Value = "WIM")] WIM,
        [EnumMember(Value = "ISO")] ISO,
        [EnumMember(Value = "VHDX")] VHDX,
        [EnumMember(Value = "VHD")] VHD,
        [EnumMember(Value = "GHO")] GHO
    }
}

