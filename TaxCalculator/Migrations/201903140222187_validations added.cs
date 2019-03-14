namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationsadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone");
            DropForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear");
            DropIndex("dbo.Citizen", new[] { "ZoneId" });
            DropIndex("dbo.HouseTaxHistory", new[] { "ToFiscalYearId" });
            AlterColumn("dbo.Citizen", "CitizenshipNo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Citizen", "District", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "KittaNo", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "Municipality", c => c.String(nullable: false));
            AlterColumn("dbo.Citizen", "ZoneId", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseTaxHistory", "HouseCategory", c => c.String(nullable: false));
            AlterColumn("dbo.HouseTaxHistory", "ToFiscalYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.Citizen", "ZoneId");
            CreateIndex("dbo.HouseTaxHistory", "ToFiscalYearId");
            AddForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear", "Id", cascadeDelete: true);
            DropColumn("dbo.HouseTaxHistory", "FY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseTaxHistory", "FY", c => c.String());
            DropForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear");
            DropForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone");
            DropIndex("dbo.HouseTaxHistory", new[] { "ToFiscalYearId" });
            DropIndex("dbo.Citizen", new[] { "ZoneId" });
            AlterColumn("dbo.HouseTaxHistory", "ToFiscalYearId", c => c.Int());
            AlterColumn("dbo.HouseTaxHistory", "HouseCategory", c => c.String());
            AlterColumn("dbo.Citizen", "ZoneId", c => c.Int());
            AlterColumn("dbo.Citizen", "Municipality", c => c.String());
            AlterColumn("dbo.Citizen", "KittaNo", c => c.String());
            AlterColumn("dbo.Citizen", "StreetName", c => c.String());
            AlterColumn("dbo.Citizen", "District", c => c.String());
            AlterColumn("dbo.Citizen", "CitizenshipNo", c => c.String(maxLength: 20));
            CreateIndex("dbo.HouseTaxHistory", "ToFiscalYearId");
            CreateIndex("dbo.Citizen", "ZoneId");
            AddForeignKey("dbo.HouseTaxHistory", "ToFiscalYearId", "dbo.FiscalYear", "Id");
            AddForeignKey("dbo.Citizen", "ZoneId", "dbo.Zone", "Id");
        }
    }
}
