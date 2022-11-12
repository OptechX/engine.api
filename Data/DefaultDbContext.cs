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
        public DbSet<LocaleIndex> LocaleIndices { get; set; }
        //public DbSet<OriginalEquipmentManufacturer> OriginalEquipmentManufacturers { get; set; }
        public DbSet<PackageDetectionIndex> PackageDetectionIndices { get; set; }
        public DbSet<TransferMethodIndex> TransferMethodIndices { get; set; }

        // Models.Generic
        public DbSet<NewsUpdate> NewsUpdates { get; set; }
    }
}

