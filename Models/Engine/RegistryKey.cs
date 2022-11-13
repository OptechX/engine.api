using System;
using System.ComponentModel.DataAnnotations;
using api.engine_v2.Models.Engine.Enums;

namespace api.engine_v2.Models.Engine
{
    public class RegistryKey
    {
        [Key]
        public int Id { get; set; }

        public Enums.RegistryHive RegistryHive { get; set; }
        public string Key { get; set; } = null!;
        public string Subkey { get; set; } = null!;
        public string ValueName { get; set; } = null!;
        public RegistryValueType ValueType { get; set; }
        public string ValueData { get; set; } = null!;
    }
}

