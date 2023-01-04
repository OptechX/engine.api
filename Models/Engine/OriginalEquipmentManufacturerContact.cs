using System;
using System.ComponentModel.DataAnnotations;
using api.engine_v2.Models.Shared;

namespace api.engine_v2.Models.Engine
{
    public class OriginalEquipmentManufacturerContact
    {
        [Key]
        public int Id { get; set; }

        public string OriginalEquipmentManufacturer { get; set; } = null!;
        public string? CountryZone { get; set; }

        [Required]
        public string OemName { get; set; } = null!;

        public string? ContactPerson { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }

        [Required]
        public string OemWebsite { get; set; } = null!;

        public string? SupportPhone { get; set; }
        public string? SupportPhoneHours { get; set; }
        public string? SupportEmail { get; set; }
        public string? SupportWebsite { get; set; }

        public string? Notes { get; set; }
    }
}

