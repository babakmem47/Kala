namespace Kala.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKalaAndFluentApi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kalas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Model = c.String(maxLength: 255),
                        Color = c.String(maxLength: 20),
                        AvailableNumber = c.Short(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kalas");
        }
    }
}
