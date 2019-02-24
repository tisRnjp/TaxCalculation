namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitizenProperty",
                c => new
                    {
                        CitizenPropertyId = c.Int(nullable: false, identity: true),
                        PropertyType = c.String(),
                        PropertyArea = c.Single(nullable: false),
                        CitizenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CitizenPropertyId)
                .ForeignKey("dbo.Citizen", t => t.CitizenId, cascadeDelete: true)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.Citizen",
                c => new
                    {
                        CitizenId = c.Int(nullable: false, identity: true),
                        CitizenshipNo = c.String(maxLength: 20),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        District = c.String(),
                        StreetName = c.String(),
                        Wardno = c.Int(nullable: false),
                        Municipality = c.String(),
                        ZoneId = c.Int(),
                    })
                .PrimaryKey(t => t.CitizenId)
                .ForeignKey("dbo.Zone", t => t.ZoneId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.CitizenHouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Floor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CitizenId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizen", t => t.CitizenId)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.CitizenLand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VDC = c.String(),
                        WardNo = c.String(),
                        SheetNo = c.String(),
                        KittaNo = c.String(),
                        ValuationArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CitizenId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizen", t => t.CitizenId)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.Zone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone");
            DropForeignKey("dbo.CitizenProperty", "CitizenId", "dbo.Citizen");
            DropForeignKey("dbo.CitizenLand", "CitizenId", "dbo.Citizen");
            DropForeignKey("dbo.CitizenHouse", "CitizenId", "dbo.Citizen");
            DropIndex("dbo.CitizenLand", new[] { "CitizenId" });
            DropIndex("dbo.CitizenHouse", new[] { "CitizenId" });
            DropIndex("dbo.Citizen", new[] { "ZoneId" });
            DropIndex("dbo.CitizenProperty", new[] { "CitizenId" });
            DropTable("dbo.Zone");
            DropTable("dbo.CitizenLand");
            DropTable("dbo.CitizenHouse");
            DropTable("dbo.Citizen");
            DropTable("dbo.CitizenProperty");
        }
    }
}