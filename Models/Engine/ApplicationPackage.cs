using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class ApplicationPackage
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string UID { get; set; } = null!;
        public string? LastUpdate { get; set; }  // yyyyMMdd
        public string Version { get; set; } = null!;
        public bool RebootRequired { get; set; } = false;

        [Required]
        public string Lcid { get; set; } = null!;
        public string CpuArch { get; set; } = null!;
        public string Filename { get; set; } = null!;
        public string Sha256 { get; set; } = null!;
        public string FollowUri { get; set; } = null!;
        public string AbsoluteUri { get; set; } = null!;

        public string Executable { get; set; } = null!;
        public string InstallCmd { get; set; } = null!;
        public string InstallArgs { get; set; } = null!;
        public string InstallScript { get; set; } = null!;          // ie - adobe that requires an install script to be passed to the pre-requirements first
        public string DisplayName { get; set; } = null!;
        public string DisplayPublisher { get; set; } = null!;
        public string DisplayVersion { get; set; } = null!;

        public string PackageDetection { get; set; } = null!;
        public string DetectValue { get; set; } = null!;
        public string DetectScript { get; set; } = null!;

        public string UninstallProcess { get; set; } = null!;      // 'UninstallProcess' == 'void' means "does not uninstall" -> drivers, for example
        public string UninstallCmd { get; set; } = null!;
        public string UninstallArgs { get; set; } = null!;
        public string UninstallScript { get; set; } = null!;

        [Required]
        public string TransferMethod { get; set; } = null!;
        //public TransferMethod TransferMethod { get; set; }          // mc, ftp, sftp, ftpes, http, https, s3, etc  (aka XFT)

        [Required]
        public string Locale { get; set; } = null!;
        // public Locale Locale { get; set; }                          // provider and the place

        public string UriPath { get; set; } = null!;                // uri for provider (can be a full string for FTP/FTPES, etc)

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

