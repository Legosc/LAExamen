namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attributes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Attributes", new[] { "ProductVariant_Id" });
            CreateTable(
                "dbo.VariantAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariantId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                        AttributeValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                
                .ForeignKey("dbo.AttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .ForeignKey("dbo.ProductVariants", t => t.VariantId)
                .Index(t => t.VariantId)
                .Index(t => t.AttributeId)
                .Index(t => t.AttributeValueId);
            
            AlterColumn("dbo.Attributes", "ProductVariant_Id", c => c.Int());
            CreateIndex("dbo.Attributes", "ProductVariant_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantAttributes", "VariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.VariantAttributes", "AttributeValueId", "dbo.AttributeValues");
            DropForeignKey("dbo.VariantAttributes", "AttributeId", "dbo.Attributes");
            DropIndex("dbo.VariantAttributes", new[] { "AttributeValueId" });
            DropIndex("dbo.VariantAttributes", new[] { "AttributeId" });
            DropIndex("dbo.VariantAttributes", new[] { "VariantId" });
            DropIndex("dbo.Attributes", new[] { "ProductVariant_Id" });
            AlterColumn("dbo.Attributes", "ProductVariant_Id", c => c.Int(nullable: false));
            DropTable("dbo.VariantAttributes");
            CreateIndex("dbo.Attributes", "ProductVariant_Id");
        }
    }
}
