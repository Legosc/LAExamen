namespace Clinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        password = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        email = p.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        password = p.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        enabled = p.Boolean(),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `Users`(
                      `email`, 
                      `password`, 
                      `enabled`) VALUES (
                      @email, 
                      @password, 
                      @enabled);
                      SELECT
                      `Id`
                      FROM `Users`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Id = p.Int(),
                        email = p.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        password = p.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        enabled = p.Boolean(),
                    },
                body:
                    @"UPDATE `Users` SET `email`=@email, `password`=@password, `enabled`=@enabled WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `Users` WHERE `Id` = @Id;"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
            DropTable("dbo.Users");
        }
    }
}
