using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class BaseImageFileTypeIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileType { get; set; } = null!;  // WIM, ISO, ZIP, SWM, etc.
    }
}

