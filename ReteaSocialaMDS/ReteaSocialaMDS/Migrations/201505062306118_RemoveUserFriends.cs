namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserFriends : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "FriendId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "FriendId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Friends");
        }
        
        public override void Down()
        {
            
        }
    }
}
