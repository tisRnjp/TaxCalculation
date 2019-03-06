namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesinlandvaluation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LandValuation", "CostPerAnna", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LandValuation", "CostPerAnna", c => c.String(nullable: false));
        }
    }
}
