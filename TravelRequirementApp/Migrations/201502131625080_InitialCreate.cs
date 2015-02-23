namespace TravelRequirementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DestinyInfoes",
                c => new
                    {
                        DestinyInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        passportvalidity = c.String(),
                    })
                .PrimaryKey(t => t.DestinyInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DestinyInfoes");
        }
    }
}
