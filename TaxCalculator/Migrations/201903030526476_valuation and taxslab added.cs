namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valuationandtaxslabadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseLandTaxSlab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        UpperLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LowerLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstSlab = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseValuation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CostPerArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepreciationRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepreciationPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HouseType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LandValuation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        LandType = c.String(nullable: false),
                        CostPerAnna = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Citizen", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizen", "FirstName", c => c.String(maxLength: 255));
            DropTable("dbo.LandValuation");
            DropTable("dbo.HouseValuation");
            DropTable("dbo.HouseLandTaxSlab");
        }
    }
}
