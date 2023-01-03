using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum WindowsEdition
    {
        [EnumMember(Value = "Home")] Home,
        [EnumMember(Value = "Pro")] Pro,
        [EnumMember(Value = "Pro N")] Pro_N,
        [EnumMember(Value = "Education")] Education,
        [EnumMember(Value = "Education N")] Education_N,
        [EnumMember(Value = "Enterprise")] Enterprise,
        [EnumMember(Value = "Enterprise N")] Enterprise_N,
        [EnumMember(Value = "Pro Education")] Pro_Education,
        [EnumMember(Value = "Pro Education N")] Pro_Education_N,
        [EnumMember(Value = "Pro for Workstations")] Pro_Workstations,
        [EnumMember(Value = "Pro N for Workstations")] Pro_N_Workstations,
        [EnumMember(Value = "Enterprise LTSC")] Enterprise_LTSC
    }
}

