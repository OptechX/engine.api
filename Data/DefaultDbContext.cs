using System;
using Microsoft.EntityFrameworkCore;
using api.engine_v2.Models.Engine;
using api.engine_v2.Models.Generic;
using api.engine_v2.Models.Shared;

namespace api.engine_v2.Data
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        // Models.Shared
        public DbSet<CountryIndex> CountryIndices { get; set; }
        public DbSet<CpuArchIndex> CpuArchIndices { get; set; }
        public DbSet<LcidIndex> LcidIndices { get; set; }
        public DbSet<Locale> locales { get; set; }
        public DbSet<LocaleIndex> LocaleIndices { get; set; }
        public DbSet<PackageDetectionIndex> PackageDetectionIndices { get; set; }
        public DbSet<TransferMethodIndex> TransferMethodIndices { get; set; }

        // Models.Generic
        public DbSet<NewsUpdate> NewsUpdates { get; set; }

        // Models.Engine
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationCategoryIndex> ApplicationCategoryIndices { get; set; }
        public DbSet<ApplicationPackage> ApplicationPackages { get; set; }
        public DbSet<AppxProvisionedPackage> AppxProvisionedPackages { get; set; }
        public DbSet<BaseImage> BaseImages { get; set; }
        public DbSet<BaseImageFileTypeIndex> BaseImageFileTypeIndices { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<DriversCore> DriverCores { get; set; }
        public DbSet<ExecutableIndex> ExecutableIndices { get; set; }
        public DbSet<ExploitReport> ExploitReports { get; set; }
        public DbSet<OrderManagement> OrderManagements { get; set; }
        //public DbSet<OrderManagement5Items> OrderManagement5Items { get; set; }
        public DbSet<OriginalEquipmentManufacturerContact> OriginalEquipmentManufacturerContacts { get; set; }
        public DbSet<RegistryKey> RegistryKeys { get; set; }
        public DbSet<UninstallProcessIndex> UninstallProcessIndices { get; set; }
        public DbSet<VirusTotalScan> VirusTotalScans { get; set; }
        public DbSet<WindowsCapability> WindowsCapabilities { get; set; }
        public DbSet<WindowsCoreIdentity> WindowsCoreIdentities { get; set; }
        public DbSet<WindowsOptionalFeature> WindowsOptionalFeatures { get; set; }
        public DbSet<WinRefCore01Release> WinRefCore01Releases { get; set; }
        public DbSet<WinRefCore02Edition> WinRefCore02Editions { get; set; }
        public DbSet<WinRefCore03Version> WinRefCore03Versions { get; set; }
        public DbSet<WinRefCore04Arch> WinRefCore04Arches { get; set; }
        public DbSet<WinRefCore05Language> WinRefCore05Languages { get; set; }
    }
}

