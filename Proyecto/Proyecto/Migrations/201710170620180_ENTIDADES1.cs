namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ENTIDADES1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUsers", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.IdentityUsers", "Client_id", "dbo.Clients");
            DropIndex("dbo.IdentityUsers", new[] { "Employee_id" });
            DropIndex("dbo.IdentityUsers", new[] { "Client_id" });
            DropColumn("dbo.IdentityUsers", "Employee_id");
            DropColumn("dbo.IdentityUsers", "Client_id");
            AlterColumn("dbo.Clients", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Clients", "UserId");
            
            CreateIndex("dbo.Employees", "UserId");
            
            AddForeignKey("dbo.Clients", "UserId", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.Employees", "UserId", "dbo.IdentityUsers", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.IdentityUsers", "Client_id", c => c.Int());
            AddColumn("dbo.IdentityUsers", "Employee_id", c => c.Int());
            DropIndex("dbo.Employees", new[] { "Contact_Id" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Clients", new[] { "Contact_Id" });
            DropIndex("dbo.Clients", new[] { "UserId" });
            AlterColumn("dbo.Employees", "UserId", c => c.String());
            AlterColumn("dbo.Clients", "UserId", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "UserId", newName: "Employee_id");
            RenameColumn(table: "dbo.Employees", name: "Contact_Id", newName: "Employee_id");
            RenameColumn(table: "dbo.Clients", name: "Contact_Id", newName: "Client_id");
            RenameColumn(table: "dbo.Clients", name: "UserId", newName: "Client_id");
            AddColumn("dbo.Employees", "UserId", c => c.String());
            AddColumn("dbo.Clients", "UserId", c => c.String());
            CreateIndex("dbo.IdentityUsers", "Client_id");
            CreateIndex("dbo.IdentityUsers", "Employee_id");
        }
    }
}
