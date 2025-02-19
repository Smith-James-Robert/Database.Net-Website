namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increase_url_limit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "ImageUrl", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Shows", "ImageUrl", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Episodes", "ImageUrl", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Episodes", "ImageUrl", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Shows", "ImageUrl", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Actors", "ImageUrl", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
