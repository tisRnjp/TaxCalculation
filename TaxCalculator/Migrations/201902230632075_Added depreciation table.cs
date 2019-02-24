namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddepreciationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depreciation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        Percentage = c.Double(nullable: false),
                        PropertyType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseTaxViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepreciationRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastYearCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CitizenHouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitizenHouse", t => t.CitizenHouse_Id)
                .Index(t => t.CitizenHouse_Id);
            
            AlterColumn("dbo.CitizenProperty", "PropertyArea", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseTaxViewModel", "CitizenHouse_Id", "dbo.CitizenHouse");
            DropIndex("dbo.HouseTaxViewModel", new[] { "CitizenHouse_Id" });
            AlterColumn("dbo.CitizenProperty", "PropertyArea", c => c.Single(nullable: false));
            DropTable("dbo.HouseTaxViewModel");
            DropTable("dbo.Depreciation");
        }
    }
}
