namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SaleLines", "Aumont");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleLines", "Aumont", c => c.Double(nullable: false));
        }
    }
}
