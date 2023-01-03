using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum OEMInstallClass
    {
        [EnumMember(Value = "Dell_cabfile")] Dell_cabfile,
        [EnumMember(Value = "Script")] Script,
        [EnumMember(Value = "Other")] Other,
        [EnumMember(Value = "LenovoExe")] LenovoExe,
        [EnumMember(Value = "DellExe")] DellExe
    }
}

