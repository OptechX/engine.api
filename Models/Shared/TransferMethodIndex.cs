using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Shared
{
    public class TransferMethodIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Method { get; set; } = null!;
    }
}

