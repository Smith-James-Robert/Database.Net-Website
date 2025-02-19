namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heighdouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "Height", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "Height", c => c.Single(nullable: false));
        }
    }
}
