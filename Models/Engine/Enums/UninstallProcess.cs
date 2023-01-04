using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum UninstallProcess
    {
        [EnumMember(Value = "void")] void_uninstall,
        [EnumMember(Value = "msi")] msi,
        [EnumMember(Value = "exe")] exe,
        [EnumMember(Value = "exe2")] exe2,
        [EnumMember(Value = "inno")] inno,
        [EnumMember(Value = "script")] script
    }
}

