namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDepreciationandAddedPropertyTypemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        DepriciationRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FiscalYear = c.String(),
                        PropertyCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CitizenHouse", "BatoKoPrakar", c => c.String());
            AddColumn("dbo.HouseTaxViewModel", "DepreciationRateLastYear", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.Depreciation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Depreciation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PropertyType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.HouseTaxViewModel", "DepreciationRateLastYear");
            DropColumn("dbo.CitizenHouse", "BatoKoPrakar");
            DropTable("dbo.PropertyType");
        }
    }
}
