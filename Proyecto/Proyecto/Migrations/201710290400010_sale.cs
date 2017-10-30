namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleLines", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaleLines", "Amount");
        }
    }
}
