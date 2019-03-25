namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredforcitizen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone");
            DropIndex("dbo.Citizen", new[] { "ZoneId" });
            AlterColumn("dbo.Citizen", "CitizenshipNo", c => c.String(maxLength: 20));
            AlterColumn("dbo.Citizen", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Citizen", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Citizen", "District", c => c.String());
            AlterColumn("dbo.Citizen", "StreetName", c => c.String());
            AlterColumn("dbo.Citizen", "KittaNo", c => c.String());
            AlterColumn("dbo.Citizen", "Municipality", c => c.String());
            AlterColumn("dbo.Citizen", "ZoneId", c => c.Int());
            CreateIndex("dbo.Citizen", "ZoneId");
            AddForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone");
            DropIndex("dbo.Citizen", new[] { "ZoneId" });
            AlterColumn("dbo.Citizen", "ZoneId", c => c.Int(nullable: false));
            AlterColumn("dbo.Citizen", "Municipality", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "KittaNo", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "District", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Citizen", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Citizen", "CitizenshipNo", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Citizen", "ZoneId");
            AddForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone", "Id", cascadeDelete: true);
        }
    }
}
