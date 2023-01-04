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
        public DbSet<CountryIndex> CountryIndices { get; set; } = null!;
        public DbSet<CpuArchIndex> CpuArchIndices { get; set; } = null!;
        public DbSet<LcidIndex> LcidIndices { get; set; } = null!;
        public DbSet<Locale> locales { get; set; } = null!;
        public DbSet<LocaleIndex> LocaleIndices { get; set; } = null!;
        public DbSet<PackageDetectionIndex> PackageDetectionIndices { get; set; } = null!;
        public DbSet<TransferMethodIndex> TransferMethodIndices { get; set; } = null!;

        // Models.Generic
        public DbSet<NewsUpdate> NewsUpdates { get; set; } = null!;

        // Models.Engine
        public DbSet<Application> Applications { get; set; } = null!;
        public DbSet<ApplicationCategoryIndex> ApplicationCategoryIndices { get; set; } = null!;
        public DbSet<ApplicationPackage> ApplicationPackages { get; set; } = null!;
        public DbSet<AppxProvisionedPackage> AppxProvisionedPackages { get; set; } = null!;
        public DbSet<BaseImage> BaseImages { get; set; } = null!;
        public DbSet<BaseImageFileTypeIndex> BaseImageFileTypeIndices { get; set; } = null!;
        public DbSet<Drivers> Drivers { get; set; } = null!;
        public DbSet<DriversCore> DriverCores { get; set; } = null!;
        public DbSet<ExecutableIndex> ExecutableIndices { get; set; } = null!;
        public DbSet<ExploitReport> ExploitReports { get; set; } = null!;
        public DbSet<OrderManagement> OrderManagements { get; set; } = null!;
        //public DbSet<OrderManagement5Items> OrderManagement5Items { get; set; }
        public DbSet<OriginalEquipmentManufacturerContact> OriginalEquipmentManufacturerContacts { get; set; } = null!;
        public DbSet<RegistryKey> RegistryKeys { get; set; } = null!;
        public DbSet<UninstallProcessIndex> UninstallProcessIndices { get; set; } = null!;
        public DbSet<VirusTotalScan> VirusTotalScans { get; set; } = null!;
        public DbSet<WindowsCapability> WindowsCapabilities { get; set; } = null!;
        public DbSet<WindowsCoreIdentity> WindowsCoreIdentities { get; set; } = null!;
        public DbSet<WindowsOptionalFeature> WindowsOptionalFeatures { get; set; } = null!;
        public DbSet<WinRefCore01Release> WinRefCore01Releases { get; set; } = null!;
        public DbSet<WinRefCore02Edition> WinRefCore02Editions { get; set; } = null!;
        public DbSet<WinRefCore03Version> WinRefCore03Versions { get; set; } = null!;
        public DbSet<WinRefCore04Arch> WinRefCore04Arches { get; set; } = null!;
        public DbSet<WinRefCore05Language> WinRefCore05Languages { get; set; } = null!;
    }
}

