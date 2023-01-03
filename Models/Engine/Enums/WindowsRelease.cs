using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum WindowsRelease
    {
        [EnumMember(Value = "Windows 7")] Windows_7,
        [EnumMember(Value = "Windows 8")] Windows_8,
        [EnumMember(Value = "Windows 8.1")] Windows_8_1,
        [EnumMember(Value = "Windows 10")] Windows_10,
        [EnumMember(Value = "Windows 11")] Windows_11
    }
}

