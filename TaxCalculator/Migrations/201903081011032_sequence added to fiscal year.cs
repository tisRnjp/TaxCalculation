namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sequenceaddedtofiscalyear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FiscalYear", "Sequence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FiscalYear", "Sequence");
        }
    }
}
