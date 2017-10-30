namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VariantAttributes", "AttributeValue_Id", "dbo.AttributeValues");
            DropIndex("dbo.VariantAttributes", new[] { "AttributeValue_Id" });
            RenameColumn(table: "dbo.VariantAttributes", name: "ProductVariant_Id", newName: "VariantId");
            RenameColumn(table: "dbo.VariantAttributes", name: "AttributeValue_Id", newName: "AttributeValueId");
            RenameIndex(table: "dbo.VariantAttributes", name: "IX_ProductVariant_Id", newName: "IX_VariantId");
            AlterColumn("dbo.VariantAttributes", "AttributeValueId", c => c.Int(nullable: false));
            CreateIndex("dbo.VariantAttributes", "AttributeValueId");
            AddForeignKey("dbo.VariantAttributes", "AttributeValueId", "dbo.AttributeValues", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantAttributes", "AttributeValueId", "dbo.AttributeValues");
            DropIndex("dbo.VariantAttributes", new[] { "AttributeValueId" });
            AlterColumn("dbo.VariantAttributes", "AttributeValueId", c => c.Int());
            RenameIndex(table: "dbo.VariantAttributes", name: "IX_VariantId", newName: "IX_ProductVariant_Id");
            RenameColumn(table: "dbo.VariantAttributes", name: "AttributeValueId", newName: "AttributeValue_Id");
            RenameColumn(table: "dbo.VariantAttributes", name: "VariantId", newName: "ProductVariant_Id");
            CreateIndex("dbo.VariantAttributes", "AttributeValue_Id");
            AddForeignKey("dbo.VariantAttributes", "AttributeValue_Id", "dbo.AttributeValues", "Id");
        }
    }
}
