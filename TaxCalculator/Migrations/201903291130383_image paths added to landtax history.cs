namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagepathsaddedtolandtaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "File", c => c.String());
            AddColumn("dbo.LandTaxHistory", "File1", c => c.String());
            AddColumn("dbo.LandTaxHistory", "File2", c => c.String());
            AddColumn("dbo.LandTaxHistory", "File3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LandTaxHistory", "File3");
            DropColumn("dbo.LandTaxHistory", "File2");
            DropColumn("dbo.LandTaxHistory", "File1");
            DropColumn("dbo.LandTaxHistory", "File");
        }
    }
}
