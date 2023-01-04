using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class WinRefCore02Edition
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string Release { get; set; } = null!;  // Release (Windows 7, Windows 8, Windows 8.1, Windows 10, Windows 11)
        public string[] Edition { get; set; } = new string[] { }; // Edition (Home, Pro, Pro N, Education, Education N, Enterprise, Enterprise N, Pro Education, Pro Education N, Pro Workstations, Pro N Workstations, Enterprise, Enterprise LTSC)

        public WinRefCore02Edition()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

