using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Shared.Enums
{
    public enum PackageDetection
    {
        [EnumMember(Value = "Registry")] Registry,
        [EnumMember(Value = "FileVersion")] FileVersion,
        [EnumMember(Value = "File")] File,
        [EnumMember(Value = "Script")] Script,
        [EnumMember(Value = "Void")] Void_Detect
    }
}

