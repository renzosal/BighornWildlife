namespace BighornWildlife.API.Migrations.AuthContext
{
    using BighornWildlife.API.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BighornWildlife.API.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AuthContext";
        }

        protected override void Seed(BighornWildlife.API.AuthContext context)
        {

            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client
                {
                    Id = "Bighorns",
                    Name = "Bighorn Wildlife",
                    Active = true,
                    ApplicationType = 0,
                    AllowedOrigin = "*",
                    RefreshTokenLifeTime = 7200,
                    Secret = Helper.GetHash("bighorns@123")
                }
                );
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
        }
    }
}
