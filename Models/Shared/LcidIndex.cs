using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Shared
{
    public class LcidIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Lcid { get; set; } = null!;
    }
}

