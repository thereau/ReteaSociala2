namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmRezolvatRelatiileFriendSiFriendReq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "OtherUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "FutureFriendUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "OtherUserId" });
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FriendRequests", new[] { "UserId" });
            DropIndex("dbo.FriendRequests", new[] { "FutureFriendUserId" });
            DropIndex("dbo.FriendRequests", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Friends", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "OtherUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FriendRequests", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FriendRequests", "FutureFriendUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Friends", "UserId");
            CreateIndex("dbo.Friends", "OtherUserId");
            CreateIndex("dbo.FriendRequests", "UserId");
            CreateIndex("dbo.FriendRequests", "FutureFriendUserId");
            AddForeignKey("dbo.Friends", "OtherUserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.FriendRequests", "FutureFriendUserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.FriendRequests", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            DropColumn("dbo.Friends", "ApplicationUser_Id");
            DropColumn("dbo.FriendRequests", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FriendRequests", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Friends", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.FriendRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "FutureFriendUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "OtherUserId", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequests", new[] { "FutureFriendUserId" });
            DropIndex("dbo.FriendRequests", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "OtherUserId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            AlterColumn("dbo.FriendRequests", "FutureFriendUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.FriendRequests", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Friends", "OtherUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Friends", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FriendRequests", "ApplicationUser_Id");
            CreateIndex("dbo.FriendRequests", "FutureFriendUserId");
            CreateIndex("dbo.FriendRequests", "UserId");
            CreateIndex("dbo.Friends", "ApplicationUser_Id");
            CreateIndex("dbo.Friends", "OtherUserId");
            CreateIndex("dbo.Friends", "UserId");
            AddForeignKey("dbo.FriendRequests", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "FutureFriendUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "OtherUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
