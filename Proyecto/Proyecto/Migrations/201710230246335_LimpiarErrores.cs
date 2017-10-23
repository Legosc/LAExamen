namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LimpiarErrores : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.VariantAttributes", "IX_AttributeId");
            DropColumn("dbo.VariantAttributes", "AttributeId");
            
            /*DropForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants"); */
        }

        public override void Down()
        {
            CreateIndex("dbo.VariantAttributes", "IX_AttributeId");
            AddColumn("dbo.VariantAttributes", "AttributeId", c => c.Int());
            /*.ForeignKey("dbo.ProductVariants", t => t.VariantId)
                .Index(t => t.VariantId) */
        }
    }
}
