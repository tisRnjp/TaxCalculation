namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiscalYearModeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FiscalYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FY = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FiscalYear");
        }
    }
}
