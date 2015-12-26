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
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.FullName).HasMaxLength(50).IsOptional();
            Property(e => e.Password).HasMaxLength(20).IsRequired();
            Property(e => e.AuthToken).HasMaxLength(100).IsOptional();
            Property(e => e.Username).HasMaxLength(50).IsRequired();

            Property(e => e.RatingId).IsRequired();
        }
    }
}
