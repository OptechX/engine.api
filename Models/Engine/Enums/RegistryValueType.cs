using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum RegistryValueType
    {
        [EnumMember(Value = "REG_SZ")] REG_SZ,
        [EnumMember(Value = "REG_BINARY")] REG_BINARY,
        [EnumMember(Value = "REG_DWORD")] REG_DWORD,
        [EnumMember(Value = "REG_MULTI_SZ")] REG_MULTI_SZ
    }
}

