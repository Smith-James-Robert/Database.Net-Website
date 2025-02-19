namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class showHasGenre1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            AddColumn("dbo.Shows", "Genre", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Shows", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "Genre_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Shows", "Genre");
            CreateIndex("dbo.Shows", "Genre_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
