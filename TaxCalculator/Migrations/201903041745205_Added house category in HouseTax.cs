namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedhousecategoryinHouseTax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "HouseCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "HouseCategory");
        }
    }
}
