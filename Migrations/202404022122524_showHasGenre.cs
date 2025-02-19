namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class showHasGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Shows", "Genre_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Shows", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Genre", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            DropColumn("dbo.Shows", "Genre_Id");
        }
    }
}
