namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class landtypeaddedtolandtaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "LandCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LandTaxHistory", "LandCategory");
        }
    }
}
