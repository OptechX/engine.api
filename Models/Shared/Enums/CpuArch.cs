using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Shared.Enums
{
    public enum CpuArch
    {
        [EnumMember(Value = "x86")] x86,
        [EnumMember(Value = "x64")] x64,
        [EnumMember(Value = "aarch32")] aarch32,
        [EnumMember(Value = "arm64")] arm64
    }
}

