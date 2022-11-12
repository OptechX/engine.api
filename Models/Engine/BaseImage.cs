using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class BaseImage
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public int SizeMB { get; set; }

        [Required]
        public string Release { get; set; } = null!;

        [Required]
        public string[] Edition { get; set; } = null!;

        [Required]
        public string Version { get; set; } = null!;
        public string? CpuArch { get; set; }
        public string[] WindowsLcid { get; set; } = new string[] { };
        public bool Fido { get; set; } = false;
        public string? BaseImageFileType { get; set; }
        public string? Locale { get; set; }
        public string? TransferMethod { get; set; }
        public string? Sha256 { get; set; }

        public BaseImage()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

