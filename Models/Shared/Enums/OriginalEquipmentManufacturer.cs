using System.Runtime.Serialization;

namespace api.engine_v2.Models.Shared
{
    public enum OriginalEquipmentManufacturer
    {
        [EnumMember(Value = "Dell")] Dell,
        [EnumMember(Value = "Lenovo")] Lenovo,
        [EnumMember(Value = "HP")] HP,
        [EnumMember(Value = "Apple")] Apple,
        [EnumMember(Value = "Acer")] Acer,
        [EnumMember(Value = "Asus")] Asus,
        [EnumMember(Value = "MSI")] MSI,
        [EnumMember(Value = "Toshiba")] Toshiba,
        [EnumMember(Value = "NEC")] NEC,
        [EnumMember(Value = "IBM")] IBM,
        [EnumMember(Value = "Compaq")] Compaq,
        [EnumMember(Value = "Packard Bell NEC")] Packard_Bell_NEC,
        [EnumMember(Value = "Fujitsu")] Fujitsu,
        [EnumMember(Value = "Sharp")] Sharp,
        [EnumMember(Value = "MSX")] MSX,
        [EnumMember(Value = "Other")] Other
    }
}

