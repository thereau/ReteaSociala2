namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FriendId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.FriendId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "FriendId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.Friends", new[] { "FriendId" });
            DropTable("dbo.Friends");
        }
    }
}
