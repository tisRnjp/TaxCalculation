namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionoffromandtofiscalyear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "FromFiscalYearId", c => c.Int());
            AddColumn("dbo.HouseTaxHistory", "ToFiscalYearId", c => c.Int());
            CreateIndex("dbo.HouseTaxHistory", "FromFiscalYearId");
            CreateIndex("dbo.HouseTaxHistory", "ToFiscalYearId");
            AddForeignKey("dbo.HouseTaxHistory", "FromFiscalYearId", "dbo.FiscalYear", "Id");
            AddForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear");
            DropForeignKey("dbo.HouseTaxHistory", "FromFiscalYearId", "dbo.FiscalYear");
            DropIndex("dbo.HouseTaxHistory", new[] { "ToFiscalYearId" });
            DropIndex("dbo.HouseTaxHistory", new[] { "FromFiscalYearId" });
            DropColumn("dbo.HouseTaxHistory", "ToFiscalYearId");
            DropColumn("dbo.HouseTaxHistory", "FromFiscalYearId");
        }
    }
}
