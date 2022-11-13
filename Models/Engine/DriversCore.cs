using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class DriversCore
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        [Required]
        public string UID { get; set; } = null!;

        [Required]
        public string OriginalEquipmentManufacturer { get; set; } = null!;

        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? ProductionYear { get; set; }
        public string[] CpuArch { get; set; } = new string[] { };
        public string[] WindowsOS { get; set; } = new string[] { };

        public DriversCore()
        {
            this.UUID = Guid.NewGuid();
            this.ProductionYear = 1900;
        }
    }
}

