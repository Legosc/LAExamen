namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categorias2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Categories", "FatherCategoryID");
            AddForeignKey("dbo.Categories", "FatherCategoryID", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "FatherCategoryID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "FatherCategoryID" });
        }
    }
}
