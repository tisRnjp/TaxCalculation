namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specific2taxhistoryidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaxHistory", "HoustTaxId", c => c.Int(nullable: false));
            AddColumn("dbo.TaxHistory", "LandTaxId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaxHistory", "LandTaxId");
            DropColumn("dbo.TaxHistory", "HoustTaxId");
        }
    }
}
