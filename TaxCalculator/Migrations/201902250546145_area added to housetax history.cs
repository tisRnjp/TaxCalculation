namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class areaaddedtohousetaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "TotalArea", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "TotalArea");
        }
    }
}
