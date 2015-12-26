using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Sql.Configurations
{
    public class MatchConfiguration : EntityTypeConfiguration<MatchEntity>
    {
        public MatchConfiguration()
        {
            ToTable("Match");
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Winner).HasMaxLength(50).IsOptional();
            Property(e => e.Boxer1).HasMaxLength(50).IsRequired();
            Property(e => e.Boxer2).HasMaxLength(50).IsRequired();
            Property(e => e.DateOfMatch).IsRequired();
            Property(e => e.Dsecription).HasMaxLength(2000).IsOptional();
            Property(e => e.Place).HasMaxLength(2000).IsRequired();
        }
    }
}
