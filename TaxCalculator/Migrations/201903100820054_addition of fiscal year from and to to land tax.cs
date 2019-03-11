namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionoffiscalyearfromandtotolandtax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "FromFiscalYearId", c => c.Int());
            AddColumn("dbo.LandTaxHistory", "ToFiscalYearId", c => c.Int());
            CreateIndex("dbo.LandTaxHistory", "FromFiscalYearId");
            CreateIndex("dbo.LandTaxHistory", "ToFiscalYearId");
            AddForeignKey("dbo.LandTaxHistory", "FromFiscalYearId", "dbo.FiscalYear", "Id");
            AddForeignKey("dbo.LandTaxHistory", "ToFiscalYearId", "dbo.FiscalYear", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandTaxHistory", "ToFiscalYearId", "dbo.FiscalYear");
            DropForeignKey("dbo.LandTaxHistory", "FromFiscalYearId", "dbo.FiscalYear");
            DropIndex("dbo.LandTaxHistory", new[] { "ToFiscalYearId" });
            DropIndex("dbo.LandTaxHistory", new[] { "FromFiscalYearId" });
            DropColumn("dbo.LandTaxHistory", "ToFiscalYearId");
            DropColumn("dbo.LandTaxHistory", "FromFiscalYearId");
        }
    }
}
