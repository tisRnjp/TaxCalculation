namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionoffiscalyeartovaluationtables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseValuation", "FiscalYearId", c => c.Int());
            AddColumn("dbo.LandValuation", "FiscalYearId", c => c.Int());
            CreateIndex("dbo.HouseValuation", "FiscalYearId");
            CreateIndex("dbo.LandValuation", "FiscalYearId");
            AddForeignKey("dbo.HouseValuation", "FiscalYearId", "dbo.FiscalYear", "Id");
            AddForeignKey("dbo.LandValuation", "FiscalYearId", "dbo.FiscalYear", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandValuation", "FiscalYearId", "dbo.FiscalYear");
            DropForeignKey("dbo.HouseValuation", "FiscalYearId", "dbo.FiscalYear");
            DropIndex("dbo.LandValuation", new[] { "FiscalYearId" });
            DropIndex("dbo.HouseValuation", new[] { "FiscalYearId" });
            DropColumn("dbo.LandValuation", "FiscalYearId");
            DropColumn("dbo.HouseValuation", "FiscalYearId");
        }
    }
}
