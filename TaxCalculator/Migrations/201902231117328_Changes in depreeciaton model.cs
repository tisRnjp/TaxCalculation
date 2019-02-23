namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changesindepreeciatonmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Depreciation", "Percentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Depreciation", "Percentage", c => c.Double(nullable: false));
        }
    }
}
