namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamesAndUserGames : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserGames", "GameId", "dbo.Games");
            DropIndex("dbo.UserGames", new[] { "UserId" });
            DropIndex("dbo.UserGames", new[] { "GameId" });
            DropTable("dbo.Games");
            DropTable("dbo.UserGames");
        }
    }
}
