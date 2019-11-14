namespace Kala.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAvailableNumberToCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kalas", "Count", c => c.Short(nullable: false));
            DropColumn("dbo.Kalas", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kalas", "Count", c => c.Short(nullable: false));
            DropColumn("dbo.Kalas", "Count");
        }
    }
}
