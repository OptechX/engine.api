using System;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum RegistryHive
    {
        [EnumMember(Value = "HKEY_LOCAL_MACHINE")] HKEY_LOCAL_MACHINE,
        [EnumMember(Value = "HKEY_USERS")] HKEY_USERS,
        [EnumMember(Value = "HKEY_CLASSES_ROOT")] HKEY_CLASSES_ROOT,
        [EnumMember(Value = "HKEY_CURRENT_CONFIG")] HKEY_CURRENT_CONFIG,
        [EnumMember(Value = "HKEY_CURRENT_USER")] HKEY_CURRENT_USER
    }
}

