using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Shared
{
    public class CpuArchIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Arch { get; set; } = null!;
    }
}

