using System;
using System.ComponentModel.DataAnnotations;
using api.engine_v2.Models.Engine.Enums;

namespace api.engine_v2.Models.Engine
{
    public class ApplicationPackage
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        [Required]
        public string UID { get; set; } = null!;
        public string? LastUpdate { get; set; }  // yyyyMMdd

        [Required]
        public string Version { get; set; } = null!;
        public bool RebootRequired { get; set; } = false;

        [Required]
        public string Lcid { get; set; } = null!;

        public string? CpuArch { get; set; }
        public string? Filename { get; set; }
        public string? Sha256 { get; set; }
        public string? FollowUri { get; set; }
        public string? AbsoluteUri { get; set; }

        public Executable Executable { get; set; }
        public string? InstallCmd { get; set; }
        public string? InstallArgs { get; set; }
        public string? InstallScript { get; set; }         // ie - adobe that requires an install script to be passed to the pre-requirements first
        public string? DisplayName { get; set; }
        public string? DisplayPublisher { get; set; }
        public string? DisplayVersion { get; set; }

        public string? PackageDetection { get; set; }
        public string? DetectValue { get; set; }
        public string? DetectScript { get; set; }

        public string? UninstallProcess { get; set; }      // 'UninstallProcess' == 'void' means "does not uninstall" -> drivers, for example
        public string? UninstallCmd { get; set; }
        public string? UninstallArgs { get; set; }
        public string? UninstallScript { get; set; }

        [Required]
        public string TransferMethod { get; set; } = null!;
        //public TransferMethod TransferMethod { get; set; }          // mc, ftp, sftp, ftpes, http, https, s3, etc  (aka XFT)

        [Required]
        public string Locale { get; set; } = null!;
        // public Locale Locale { get; set; }                          // provider and the place

        public string? UriPath { get; set; }                // uri for provider (can be a full string for FTP/FTPES, etc)

        public bool Enabled { get; set; } = true;
        public string[] DependsOn { get; set; } = new string[] { };
        public int? VirusTotalScanResultsId { get; set; }
        public int? ExploitReportId { get; set; }

        public ApplicationPackage()
        {
            this.UUID = Guid.NewGuid();
            this.LastUpdate = DateTime.Today.ToString("yyyyMMdd");
        }

    }
}

