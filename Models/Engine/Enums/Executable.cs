using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum Executable
    {
        [EnumMember(Value = "msi")] msi,
        [EnumMember(Value = "msix")] msix,
        [EnumMember(Value = "exe")] exe,
        [EnumMember(Value = "bat")] bat,
        [EnumMember(Value = "ps1")] ps1,
        [EnumMember(Value = "zip")] zip,
        [EnumMember(Value = "script")] script,
        [EnumMember(Value = "cab")] cabfile
    }
}

