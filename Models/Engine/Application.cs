using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        [Required]
        public string UID { get; set; } = null!;

        [Required]
        public string LastUpdate { get; set; } = String.Empty;

        [Required]
        public string ApplicationCategory { get; set; } = null!;

        [Required]
        public string Publisher { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Version { get; set; } = null!;

        public string Copyright { get; set; } = null!;
        public bool LicenseAcceptRequired { get; set; } = false;

        public string[] Lcid { get; set; } = new string[] { };
        public string[] CpuArch { get; set; } = new string[] { };

        public string Homepage { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Docs { get; set; } = null!;
        public string License { get; set; } = null!;
        public string[] Tags { get; set; } = new string[] { };
        public string Summary { get; set; } = null!;

        public bool Enabled { get; set; } = true;

        public Application()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

