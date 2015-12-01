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
    public class PredictionConfiguration : EntityTypeConfiguration<PredictionEntity>
    {
        public PredictionConfiguration()
        {
            ToTable("Predictions");
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Winner).HasMaxLength(50).IsRequired();
            Property(e => e.UserId).IsRequired();
            Property(e => e.MatchId).IsRequired();
        }
    }
}
