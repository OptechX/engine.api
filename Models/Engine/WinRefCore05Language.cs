using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class WinRefCore05Language
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string Release { get; set; } = String.Empty;  // Release (Windows 7, Windows 8, Windows 8.1, Windows 10, Windows 11)
        public string Edition { get; set; } = String.Empty;  // Edition (Home, Pro, Pro N, Education, Education N, Enterprise, Enterprise N, Pro Education, Pro Education N, Pro Workstations, Pro N Workstations, Enterprise, Enterprise LTSC)
        public string Version { get; set; } = String.Empty;  // Version (21H2, 21H1, 20H2, 2004, 1909, 1903, 1809, 1809, 1803, 1709, 1703, 1607, 1511, 1507)
        public string Arch { get; set; } = String.Empty;  // Arch (x64, x86)
        public string[] Language { get; set; } = new string[] { };  // Language (English, etc)

        public WinRefCore05Language()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

