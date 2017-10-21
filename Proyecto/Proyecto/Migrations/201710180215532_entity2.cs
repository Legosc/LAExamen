namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IdentityUsers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IdentityUsers", "Phone", c => c.Int());
        }
    }
}
