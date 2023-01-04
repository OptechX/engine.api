using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Shared
{
    public class CountryIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}

