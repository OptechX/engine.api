using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Shared
{
    public class LocaleIndex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Provider { get; set; } = null!;
        public string ProviderCode { get; set; } = null!;
        public string ProviderUID { get; set; } = null!;
        public string ProviderXFT { get; set; } = null!;
        public string ProviderUserId { get; set; } = null!;
        public string ProviderPasswd { get; set; } = null!;
        public string ProviderExt1 { get; set; } = null!;
        public string ProviderExt2 { get; set; } = null!;
        public string ProviderExt3 { get; set; } = null!;
        public string ProviderExt4 { get; set; } = null!;
    }
}

