namespace TravelRequirementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinyInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinyInfoes", "Destination", c => c.String());
            DropColumn("dbo.DestinyInfoes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DestinyInfoes", "Name", c => c.String());
            DropColumn("dbo.DestinyInfoes", "Destination");
        }
    }
}
