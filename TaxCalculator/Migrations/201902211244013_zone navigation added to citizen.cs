namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zonenavigationaddedtocitizen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citizen", "Zone_Id", c => c.Int());
            CreateIndex("dbo.Citizen", "Zone_Id");
            AddForeignKey("dbo.Citizen", "Zone_Id", "dbo.Zone", "Id");
            DropColumn("dbo.Citizen", "ZoneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citizen", "ZoneId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Citizen", "Zone_Id", "dbo.Zone");
            DropIndex("dbo.Citizen", new[] { "Zone_Id" });
            DropColumn("dbo.Citizen", "Zone_Id");
        }
    }
}
