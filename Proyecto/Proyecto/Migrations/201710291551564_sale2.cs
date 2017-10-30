namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleLines", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaleLines", "UnitPrice");
        }
    }
}
