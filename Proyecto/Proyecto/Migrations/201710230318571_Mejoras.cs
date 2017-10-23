namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mejoras : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants");
            AddForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants");
            AddForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants", "Id");
        }
    }
}
