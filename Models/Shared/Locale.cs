using System.ComponentModel.DataAnnotations;
using api.engine_v2.Models.Shared.Enums;

namespace api.engine_v2.Models.Shared
{
    public class Locale
    {
        [Key]
        public int Id { get; set; }

        public string LookUp { get; set; } = null!;           // upcloud_au_syd_07
        public string Value { get; set; } = null!;            // upcloud/au-syd1-07
        public TransferMethod? TransferMethod { get; set; }   // mc
        public string? Host { get; set; }                     // s3://fish.aws.com
        public int? Port { get; set; }                        // 222
        public string? Username { get; set; }                 // john
        public string? Password { get; set; }                 // theFisherm4n
    }
}

//(Legacy Code)
//public enum Locale
//{
//    [EnumMember(Value = "upcloud/au-syd1-07")] upcloud_au_syd_07
//}

