namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendRequestsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FutureFriendUserId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FutureFriendUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.UserId)
                .Index(t => t.FutureFriendUserId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "FutureFriendUserId", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FriendRequests", new[] { "FutureFriendUserId" });
            DropIndex("dbo.FriendRequests", new[] { "UserId" });
            DropTable("dbo.FriendRequests");
        }
    }
}
