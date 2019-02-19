namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcreation : DbMigration
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
                        FirstName = c.String(),
                        LastName = c.String(),
                        Zone = c.String(),
                        District = c.String(),
                        StreetName = c.String(),
                        Wardno = c.Int(nullable: false),
                        Municipality = c.String(),
                    })
                .PrimaryKey(t => t.CitizenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CitizenProperty", "CitizenId", "dbo.Citizen");
            DropIndex("dbo.CitizenProperty", new[] { "CitizenId" });
            DropTable("dbo.Citizen");
            DropTable("dbo.CitizenProperty");
        }
    }
}
