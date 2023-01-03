using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Generic
{
    public class NewsUpdate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ArticleImage { get; set; } = null!;

        [Required]
        public string ArticleHeading { get; set; } = null!;

        [Required]
        public string ArticlePreview { get; set; } = null!;

        [Required]
        public string ArticleLink { get; set; } = null!;
    }
}

