using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class UninstallProcessIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Method { get; set; } = null!;  // msi, exe, exe2, inno, script
    }
}

