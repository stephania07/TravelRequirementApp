namespace TravelRequirementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinyInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinyInfoes", "CurrencyRestriction", c => c.String());
            AddColumn("dbo.DestinyInfoes", "Vaccination", c => c.String());
            AddColumn("dbo.DestinyInfoes", "TouristVisaRequirement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DestinyInfoes", "TouristVisaRequirement");
            DropColumn("dbo.DestinyInfoes", "Vaccination");
            DropColumn("dbo.DestinyInfoes", "CurrencyRestriction");
        }
    }
}
