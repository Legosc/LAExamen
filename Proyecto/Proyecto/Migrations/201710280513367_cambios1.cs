namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VariantAttributes", "AttributeValueId", "dbo.AttributeValues");
            DropIndex("dbo.VariantAttributes", new[] { "AttributeValueId" });
            RenameColumn(table: "dbo.VariantAttributes", name: "VariantId", newName: "ProductVariant_Id");
            RenameColumn(table: "dbo.VariantAttributes", name: "AttributeValueId", newName: "AttributeValue_Id");
            RenameIndex(table: "dbo.VariantAttributes", name: "IX_VariantId", newName: "IX_ProductVariant_Id");
            AlterColumn("dbo.VariantAttributes", "AttributeValue_Id", c => c.Int());
            CreateIndex("dbo.VariantAttributes", "AttributeValue_Id");
            AddForeignKey("dbo.VariantAttributes", "AttributeValue_Id", "dbo.AttributeValues", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantAttributes", "AttributeValue_Id", "dbo.AttributeValues");
            DropIndex("dbo.VariantAttributes", new[] { "AttributeValue_Id" });
            AlterColumn("dbo.VariantAttributes", "AttributeValue_Id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.VariantAttributes", name: "IX_ProductVariant_Id", newName: "IX_VariantId");
            RenameColumn(table: "dbo.VariantAttributes", name: "AttributeValue_Id", newName: "AttributeValueId");
            RenameColumn(table: "dbo.VariantAttributes", name: "ProductVariant_Id", newName: "VariantId");
            CreateIndex("dbo.VariantAttributes", "AttributeValueId");
            AddForeignKey("dbo.VariantAttributes", "AttributeValueId", "dbo.AttributeValues", "Id", cascadeDelete: true);
        }
    }
}
