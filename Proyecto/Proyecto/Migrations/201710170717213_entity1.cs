namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ApplicationUser_Id", c => c.String());
            AddColumn("dbo.Clients", "ApplicationUser_Id", c => c.String());
            /*CreateIndex("dbo.Employees", "IX_ApplicationUser_Id");
            CreateIndex("dbo.Clients", "IX_ApplicationUser_Id");*/
        }

        public override void Down()
        {
            
            DropColumn("dbo.Clients", "ApplicationUser_Id");
            DropColumn("dbo.Employees", "ApplicationUser_Id");
            /*DropIndex("dbo.Clients", new[] { "IX_ApplicationUser_Id" });
            
            DropIndex("dbo.Employees", new[] { "IX_ApplicationUser_Id" });*/
            
        }
    }
}
