using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class ApplicationCategoryIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Category { get; set; } = null!;
    }
}

