using Boxing.Core.Sql.Configurations;
using Boxing.Core.Sql.Entities;
using Boxing.Core.Sql.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Sql
{
    public class BoxingContext : DbContext
    {
        public BoxingContext() :
            base("boxingConnection")
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<PredictionEntity> Predictions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new MatchConfiguration());
            modelBuilder.Configurations.Add(new PredictionConfiguration());
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BoxingContext, Configuration>());
        }
    }
}
