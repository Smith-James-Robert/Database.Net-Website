namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alt_not_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "AlternativeName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "AlternativeName", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
