using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class Drivers
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        [Required]
        public string UID { get; set; } = null!;

        public string OriginalEquipmentManufacturer { get; set; } = String.Empty;

        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;

        public string? CspVersion { get; set; } = String.Empty;  // used for Lenovo only
        public string? CspName { get; set; } = String.Empty;  // used for Lenovo only

        public string Version { get; set; } = null!;  // current Drivers package version
        public string BiosVersion { get; set; } = null!;  // current BIOS version

        public int? ProductionYear { get; set; }   // when was the PC introduced to market?
        public string[] CpuArch { get; set; } = null!;

        public string OEMInstallClass { get; set; } = null!;

        public bool x64 { get; set; } = false;
        public bool x86 { get; set; } = false;
        public bool? arm64 { get; set; } = false;
        public bool? aarch32 { get; set; } = false;

        public string Uri { get; set; } = null!;
        public string OutFile { get; set; } = null!;

        public bool Latest { get; set; }
        public string? LastUpdate { get; set; }  // yyyyMMdd

        [Required]
        public string WindowsRelease { get; set; } = null!;

        public string[] SupportedWindowsVersion { get; set; } = new string[] { };

        public string? UrlVTScan { get; set; } = String.Empty;
        public int? ExploitReportId { get; set; }

        public string WmiObjectName { get; set; } = null!;  //repasscloud/optechx.api.engine/issues/15
        public string WmiObjectVendor { get; set; } = null!;  //repasscloud/optechx.api.engine/issues/15
        public string WmiObjectVersion { get; set; } = null!;  //repasscloud/optechx.api.engine/issues/15
        public string WmiObjectCaption { get; set; } = null!;  //repasscloud/optechx.api.engine/issues/15

        public bool CloudDeploySupport { get; set; } = false;

        public string? ScriptInstall { get; set; } = String.Empty;

        public string? Notes { get; set; } = String.Empty;

        public Drivers()
        {
            this.UUID = Guid.NewGuid();
            this.ProductionYear = 1900;
            this.ExploitReportId = 0;
            this.CloudDeploySupport = false;
            this.LastUpdate = DateTime.Today.ToString("yyyyMMdd");
        }
    }
}

