namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taxhistoryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaxHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitizenId = c.Int(nullable: false),
                        HousTotalArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HousGrossCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HousLastFYGrossCost = c.Decimal(precision: 18, scale: 2),
                        ToFY = c.String(),
                        FromFY = c.String(),
                        LandTaxKittaNo = c.String(),
                        LandTaxLastFYCost = c.Int(),
                        LandTaxCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LandTaxArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValuation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaxHistory");
        }
    }
}
