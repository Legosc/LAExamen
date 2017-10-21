namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ENTIDADES : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRoles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "IdentityUsers");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogins");
            DropIndex("dbo.IdentityRoles", "RoleNameIndex");
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.IdentityUserRoles");
            DropPrimaryKey("dbo.IdentityUserLogins");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FatherCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        WishList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.WishLists", t => t.WishList_Id)
                .Index(t => t.ProductId)
                .Index(t => t.WishList_Id);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductVariant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariant_Id)
                .Index(t => t.ProductVariant_Id);
            
            CreateTable(
                "dbo.AttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributeId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Actived = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SaleDate = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.SaleLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Aumont = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVariants", t => t.VariantId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            AddColumn("dbo.IdentityUserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUsers", "Name", c => c.String());
            AddColumn("dbo.IdentityUsers", "Phone", c => c.Int());
            AddColumn("dbo.IdentityUsers", "Address", c => c.String());
            AddColumn("dbo.IdentityUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.IdentityUsers", "Employee_id", c => c.Int());
            AddColumn("dbo.IdentityUsers", "Client_id", c => c.Int());
            AddColumn("dbo.IdentityUserClaims", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogins", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String());
            AlterColumn("dbo.IdentityUsers", "Email", c => c.String());
            AlterColumn("dbo.IdentityUsers", "UserName", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String());
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "RoleId", "UserId" });
            AddPrimaryKey("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.IdentityUsers", "Employee_id");
            CreateIndex("dbo.IdentityUsers", "Client_id");
            CreateIndex("dbo.IdentityUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserLogins", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserRoles", "IdentityUser_Id");
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.IdentityUsers", "Employee_id", "dbo.Employees", "id");
            AddForeignKey("dbo.IdentityUsers", "Client_id", "dbo.Clients", "id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.WishLists", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ProductVariants", "WishList_Id", "dbo.WishLists");
            DropForeignKey("dbo.Sales", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.IdentityUsers", "Client_id", "dbo.Clients");
            DropForeignKey("dbo.SaleLines", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.SaleLines", "VariantId", "dbo.ProductVariants");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.IdentityUsers", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Attributes", "ProductVariant_Id", "dbo.ProductVariants");
            DropForeignKey("dbo.AttributeValues", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WishLists", new[] { "ClientId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.SaleLines", new[] { "VariantId" });
            DropIndex("dbo.SaleLines", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "ClientId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", new[] { "Client_id" });
            DropIndex("dbo.IdentityUsers", new[] { "Employee_id" });
            DropIndex("dbo.AttributeValues", new[] { "AttributeId" });
            DropIndex("dbo.Attributes", new[] { "ProductVariant_Id" });
            DropIndex("dbo.ProductVariants", new[] { "WishList_Id" });
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.IdentityUserLogins");
            DropPrimaryKey("dbo.IdentityUserRoles");
            AlterColumn("dbo.IdentityUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.IdentityUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.IdentityRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.IdentityUserLogins", "IdentityUser_Id");
            DropColumn("dbo.IdentityUserClaims", "IdentityUser_Id");
            DropColumn("dbo.IdentityUsers", "Client_id");
            DropColumn("dbo.IdentityUsers", "Employee_id");
            DropColumn("dbo.IdentityUsers", "Discriminator");
            DropColumn("dbo.IdentityUsers", "Address");
            DropColumn("dbo.IdentityUsers", "Phone");
            DropColumn("dbo.IdentityUsers", "Name");
            DropColumn("dbo.IdentityUserRoles", "IdentityRole_Id");
            DropColumn("dbo.IdentityUserRoles", "IdentityUser_Id");
            DropTable("dbo.WishLists");
            DropTable("dbo.SaleLines");
            DropTable("dbo.Sales");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.AttributeValues");
            DropTable("dbo.Attributes");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.IdentityUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.IdentityUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.IdentityUserLogins", "UserId");
            CreateIndex("dbo.IdentityUserClaims", "UserId");
            CreateIndex("dbo.IdentityUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.IdentityUserRoles", "RoleId");
            CreateIndex("dbo.IdentityUserRoles", "UserId");
            CreateIndex("dbo.IdentityRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.IdentityUsers", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.IdentityRoles", newName: "AspNetRoles");
        }
    }
}
