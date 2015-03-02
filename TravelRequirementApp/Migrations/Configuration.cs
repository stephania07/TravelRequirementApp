namespace TravelRequirementApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelRequirementApp.DestinationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TravelRequirementApp.DestinationContext";
        }

        protected override void Seed(TravelRequirementApp.DestinationContext context)
        {
            //  This method will be called after migrating to the latest version.
                context.Destinations.AddOrUpdate<Model.DestinyInfo>(
                n => n.Destination,
                new Model.DestinyInfo { Destination = "Thailand", CurrencyRestriction = "Not required", PassportValidity = "Six month from the date of entry", TouristVisaRequirement = "Not required for stay under 30days", Vaccination = "Yellow Fever may be required", Note = " " }
                );
                
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
