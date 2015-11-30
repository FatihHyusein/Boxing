namespace Boxing.Core.Sql.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Boxing.Core.Sql.BoxingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Boxing.Core.Sql.BoxingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //context.Users.AddOrUpdate(
            //  p => p.FullName,
            //  new Entities.UserEntity { FullName = "Andrew Peters" },
            //  new Entities.UserEntity { FullName = "Brice Lambson" },
            //  new Entities.UserEntity { FullName = "Rowan Miller" }
            //);

            //context.Matches.AddOrUpdate(
            //  p => p.Dsecription,
            //  new Entities.MatchEntity { Dsecription = "Dafuq" }
            //);
        }
    }
}
