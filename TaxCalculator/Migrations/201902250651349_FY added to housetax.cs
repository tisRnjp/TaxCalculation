namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FYaddedtohousetax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "FY", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "FY");
        }
    }
}
