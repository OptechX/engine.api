using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class WinRefCore01Release
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string[] Release { get; set; } = new string[] { }; // Release (Windows 7, Windows 8, Windows 8.1, Windows 10, Windows 11)

        public WinRefCore01Release()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

