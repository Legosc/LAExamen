namespace Examen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mejorasdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUsers", newName: "IdentityUsers");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            AddColumn("dbo.IdentityUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddForeignKey("dbo.Dates", "UserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dates", "UserId", "dbo.IdentityUsers");
            DropColumn("dbo.IdentityUsers", "Discriminator");
            RenameIndex(table: "dbo.IdentityUserRoles", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserLogins", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.IdentityUserClaims", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserRoles", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserLogins", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.IdentityUserClaims", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.IdentityUsers", newName: "ApplicationUsers");
        }
    }
}
