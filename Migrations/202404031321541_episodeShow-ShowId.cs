namespace JS2247A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class episodeShowShowId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Episodes", name: "ShowId", newName: "Show_Id");
            RenameIndex(table: "dbo.Episodes", name: "IX_ShowId", newName: "IX_Show_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Episodes", name: "IX_Show_Id", newName: "IX_ShowId");
            RenameColumn(table: "dbo.Episodes", name: "Show_Id", newName: "ShowId");
        }
    }
}
