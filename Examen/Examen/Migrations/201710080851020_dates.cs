namespace Examen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        Reservation = c.DateTime(nullable: false),
                        Details = c.String(),
                        Duration = c.Int(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: false)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dates", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Dates", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Dates", new[] { "ContactId" });
            DropIndex("dbo.Dates", new[] { "UserId" });
            DropTable("dbo.Dates");
        }
    }
}
