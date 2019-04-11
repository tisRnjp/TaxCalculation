namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldsaddedtotaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaxHistory", "TotalYears", c => c.Int());
            AddColumn("dbo.TaxHistory", "LastFYTotalValuation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TaxHistory", "LandTaxLastFYCost", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaxHistory", "LandTaxLastFYCost", c => c.Int());
            DropColumn("dbo.TaxHistory", "LastFYTotalValuation");
            DropColumn("dbo.TaxHistory", "TotalYears");
        }
    }
}
