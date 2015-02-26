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
            AutomaticMigrationsEnabled = false;
            ContextKey = "TravelRequirementApp.DestinationContext";
        }

        protected override void Seed(TravelRequirementApp.DestinationContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Destinations.AddOrUpdate<Model.DestinyInfo>(
                n => n.Destination,//ANY LINQ expression
                new Model.DestinyInfo { Destination = "South Africa", CurrencyRestriction = "must be declared", PassportValidity="six month", TouristVisaRequirement="Not required", Vaccination="None"}

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
