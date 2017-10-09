namespace Examen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datesusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dates", "UserId", "dbo.IdentityUsers");
            AddColumn("dbo.Dates", "ClinicaUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Dates", "ClinicaUser_Id");
            AddForeignKey("dbo.Dates", "ClinicaUser_Id", "dbo.IdentityUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dates", "ClinicaUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.Dates", new[] { "ClinicaUser_Id" });
            DropColumn("dbo.Dates", "ClinicaUser_Id");
            AddForeignKey("dbo.Dates", "UserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
        }
    }
}
