namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity : DbMigration
    {
        public override void Up()
        {
            /*RenameColumn(table: "dbo.Clients", name: "Contact_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Employees", name: "Contact_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Clients", name: "IX_Contact_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_Contact_Id", newName: "IX_ApplicationUser_Id");*/
        }
        
        public override void Down()
        {
            /*RenameIndex(table: "dbo.Employees", name: "IX_ApplicationUser_Id", newName: "IX_Contact_Id");
            RenameIndex(table: "dbo.Clients", name: "IX_ApplicationUser_Id", newName: "IX_Contact_Id");
            RenameColumn(table: "dbo.Employees", name: "ApplicationUser_Id", newName: "Contact_Id");
            RenameColumn(table: "dbo.Clients", name: "ApplicationUser_Id", newName: "Contact_Id");*/
        }
    }
}
