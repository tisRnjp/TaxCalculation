namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalyearaddedtohousetax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "TotalYears", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "TotalYears");
        }
    }
}
