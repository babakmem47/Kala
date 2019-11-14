namespace Kala.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedPropToKala : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kalas", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kalas", "Deleted");
        }
    }
}
