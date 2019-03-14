namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualvaluationareaandremarksaddedtolandtaxvaluation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "ActualValuationArea", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LandTaxHistory", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LandTaxHistory", "Remarks");
            DropColumn("dbo.LandTaxHistory", "ActualValuationArea");
        }
    }
}
