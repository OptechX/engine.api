using System;
using System.ComponentModel.DataAnnotations;

namespace api.engine_v2.Models.Engine
{
    public class OrderManagement
    {
        [Key]
        public int Id { get; set; }

        public Guid? UUID { get; set; }

        [Required]
        public int AccountId { get; set; }

        public string OrderDate { get; set; } = String.Empty;
        public string OrderStatus { get; set; } = String.Empty;

        [StringLength(20)]
        public string OrderName { get; set; } = String.Empty;
        public string? DownloadLink { get; set; }
        public string? ImageOutputFormat { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string NotificationEmailAddress { get; set; } = String.Empty;
        public bool ContinuousIntegration { get; set; }
        public bool ContinuousDelivery { get; set; }

        public string Release { get; set; } = null!;
        public string Edition { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string Arch { get; set; } = null!;
        public string Lcid { get; set; } = null!;

        public string? OptionalFeatureString { get; set; }
        public string? AppxPackagesString { get; set; }

        [StringLength(20), RegularExpression(@"[a-zA-Z0-9_.-]{1,20}", ErrorMessage = "Username must contain A-Z, a-z, 0-9, '.', '-', '_' characters up to length of 20 only.")]
        public string WindowsDefaultAccount { get; set; } = String.Empty;

        [Required, RegularExpression(@".{8,40}", ErrorMessage = "Password must have min, max of 8,40 characters.")]
        public string WindowsDefaultPassword { get; set; } = null!;

        public string[] CustomRegistryKeys { get; set; } = new string[] { };

        public string[] ApplicationUID { get; set; } = new string[] { };  // list of Application.UID
        public string[] DriversUID { get; set; } = new string[] { };      // list of Drivers.uid

        public OrderManagement()
        {
            // a-z Ambiguous: l
            // A-Z Ambiguous: IO
            // 0-9 Ambiguous: 01

            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var stringChars = new char[7];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var todayDate = DateTime.Today;
            string strToday = todayDate.ToString("yyyyMMdd");
            string srtTodayOrder = todayDate.ToString("yyyy-MM-dd");

            this.UUID = Guid.NewGuid();
            this.OrderStatus = "Submitted";
            this.OrderName = finalString + "_" + strToday;
            this.OrderDate = srtTodayOrder;
            this.ContinuousIntegration = false;
            this.ContinuousDelivery = false;
            this.ImageOutputFormat = "WIM";
        }
    }

    public class OrderManagement5Items
    {
        public string OrderName { get; set; } = String.Empty;
        public string Date { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
    }
}

