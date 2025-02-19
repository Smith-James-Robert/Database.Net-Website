namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heighdecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "Height", c => c.Int(nullable: false));
        }
    }
}
