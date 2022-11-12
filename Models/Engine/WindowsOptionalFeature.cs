using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class WindowsOptionalFeature
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string FeatureName { get; set; } = null!;
        public bool Enabled { get; set; }
        public string[] SupportedWindowsVersions { get; set; } = new string[] { };  // WindowsVersion (v21H2, v21H1, v20H2, v2004, v1909, v1903, v1809, v1809, v1803, v1709, v1703, v1607, v1511, v1507)
        public string[] SupportedWindowsEditions { get; set; } = new string[] { };  // WindowsEdition (Home, Pro, Pro_N, Education, Education_N, Enterprise, Enterprise_N, Pro_Education, Pro_Education_N, Pro_Workstations,Pro_N_Workstations, Enterprise_LTSC)
        public string[] SupportedWindowsReleases { get; set; } = new string[] { };  // WindowsRelease (Windows_7, Windows_8, Windows_8_1, Windows_10, Windows_11)

        public WindowsOptionalFeature()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

