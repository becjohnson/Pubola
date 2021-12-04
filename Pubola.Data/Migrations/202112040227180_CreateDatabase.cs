namespace Pubola.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genre", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.GraphicNovel", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Magazine", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Genre", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Magazine", "UserId");
            DropColumn("dbo.GraphicNovel", "UserId");
            DropColumn("dbo.Genre", "UserId");
        }
    }
}
