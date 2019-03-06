namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RangeaddedtoTaxSlab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseLandTaxSlab", "Range", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.LandValuation", "CostPerAnna", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LandValuation", "CostPerAnna", c => c.String(nullable: false));
            DropColumn("dbo.HouseLandTaxSlab", "Range");
        }
    }
}
