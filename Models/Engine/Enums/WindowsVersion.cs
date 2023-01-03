using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum WindowsVersion
    {
        [EnumMember(Value = "1507")] v1507,
        [EnumMember(Value = "1511")] v1511,
        [EnumMember(Value = "1607")] v1607,
        [EnumMember(Value = "1703")] v1703,
        [EnumMember(Value = "1709")] v1709,
        [EnumMember(Value = "1803")] v1803,
        [EnumMember(Value = "1809")] v1809,
        [EnumMember(Value = "1903")] v1903,
        [EnumMember(Value = "1909")] v1909,
        [EnumMember(Value = "2004")] v2004,
        [EnumMember(Value = "20H2")] v20H2,
        [EnumMember(Value = "21H1")] v21H1,
        [EnumMember(Value = "21H2")] v21H2,
        [EnumMember(Value = "22H1")] v22H1
    }
}

