using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class ExecutableIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;  // msi, msix, exe, bat, ps1, etc
    }
}

