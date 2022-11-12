using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class VirusTotalScan
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        public string HashScanned { get; set; } = null!;        // SHA256 (used by files)
        public string Filename { get; set; } = null!;           // filename of object scanned
        public string UriScanned { get; set; } = String.Empty;  // URL (used by URI)
        public string UriScanId { get; set; } = String.Empty;   // scan ID of uri (used by URI)
        public string Tlsh { get; set; } = null!;               // $response.data.attributes.tlsh
        public string Vhash { get; set; } = null!;              // $response.data.attributes.vhash
        public int StatsHarmless { get; set; }                  // $response.data.attributes.last_analysis_stats.harmless
        public int StatsTypeUnsupported { get; set; }           // $response.data.attributes.last_analysis_stats.type-unsupported
        public int StatsSuspicious { get; set; }                // $response.data.attributes.last_analysis_stats.suspicious
        public int StatsConfirmedTimeout { get; set; }          // $response.data.attributes.last_analysis_stats.confirmed-timeout
        public int StatsTimeout { get; set; }                   // $response.data.attributes.last_analysis_stats.timeout
        public int StatsFailure { get; set; }                   // $response.data.attributes.last_analysis_stats.failure
        public int StatsMalicious { get; set; }                 // $response.data.attributes.last_analysis_stats.malicious
        public int StatsUndetected { get; set; }                // $response.data.attributes.last_analysis_stats.undetected
        public int StatsTotalCount { get; set; }                // $total = $harmless + $type_unsupported + $suspicious + $confirmed_timeout + $timeout + $failure + $malicious + $undetected
        public int StatsSafetyPercentage { get; set; }          // $percent_safe = [int]((($harmless+$undetected)/$total) * 100)
        public bool IsSafe { get; set; }                        // anything less than 51% safe is $false

        public VirusTotalScan()
        {
            this.UUID = Guid.NewGuid();
        }
    }
}

