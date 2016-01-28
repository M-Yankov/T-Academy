namespace CountriesDataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataBaseContext context)
        {
            if (context.Contintents.Any())
            {
                return;
            }

            Contintent northAmerica = new Contintent() { Name = "NorthAmerica" };
            Contintent europe = new Contintent() { Name = "Europe" };
            context.Contintents.AddOrUpdate(northAmerica, europe);
            context.SaveChanges();

            Country Bulgatia = new Country()
            {
                ContinentId = europe.Id, Language = "BG", Name = "Bulgaria", Population = 1231525
            };

            Country Usa = new Country()
            {
                ContinentId = northAmerica.Id,
                Language = "US",
                Name = "United States of America",
                Population = 41371525
            };
            context.Countries.AddOrUpdate(Usa, Bulgatia);
            context.SaveChanges();

            Town sofia = new Town() { CountryId = Bulgatia.Id, Name = "Sofia", Population = 1561213 };
            Town newYourk = new Town() { CountryId = Usa.Id, Name = "New Your", Population = 71562262 };

            context.Towns.AddOrUpdate(sofia, newYourk);
            context.SaveChanges();

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
