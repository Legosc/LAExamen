namespace Examen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image", c => c.Byte(nullable: false));
        }
    }
}
