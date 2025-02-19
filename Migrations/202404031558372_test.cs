namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ShowId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "ShowId");
        }
    }
}
