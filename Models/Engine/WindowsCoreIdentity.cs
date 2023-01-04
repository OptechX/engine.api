using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class WindowsCoreIdentity
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string UID { get; set; } = null!;

        [Required]
        public string Release { get; set; } = null!; // WindowsRelease (Windows_7, Windows_8, Windows_8_1, Windows_10, Windows_11)

        [Required]
        public string Edition { get; set; } = null!; // WindowsEdition (Home, Pro, Pro_N, Education, Education_N, Enterprise, Enterprise_N, Pro_Education, Pro_Education_N, Pro_Workstations,Pro_N_Workstations, Enterprise_LTSC)

        [Required]
        public string Version { get; set; } = null!; // WindowsVersion (v21H2, v21H1, v20H2, v2004, v1909, v1903, v1809, v1809, v1803, v1709, v1703, v1607, v1511, v1507)

        [Required]
        public string Build { get; set; } = null!;   // 19042 ,19043, 19044, etc

        [Required]
        public string Arch { get; set; } = null!;

        [Required]
        public string WindowsLcid { get; set; } = null!;

        public string? SupportedUntil { get; set; }  // date for EOL

        public WindowsCoreIdentity()
        {
            this.UUID = Guid.NewGuid();
            // this.UID = this.Release.Replace(" ","").ToLower() + "::" + 
            //     this.Edition.Replace(" ","").ToLower() + "::" + 
            //     this.Version.Replace(" ","").ToLower() + "::" + 
            //     this.Build.Replace(" ","").ToLower() + "::" + 
            //     this.Arch.Replace(" ","").ToLower() + "::" +
            //     this.WindowsLcid.Replace(" ","").Replace("(","").Replace(")","").ToLower();
            this.SupportedUntil = "1900-12-31";
        }
    }
}

