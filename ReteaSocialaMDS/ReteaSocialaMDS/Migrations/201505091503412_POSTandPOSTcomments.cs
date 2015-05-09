namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POSTandPOSTcomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ParentPostId = c.Int(nullable: false),
                        CommentPostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.ParentPostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ParentPostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostComments", "ParentPostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.PostComments", new[] { "ParentPostId" });
            DropIndex("dbo.PostComments", new[] { "UserId" });
            DropTable("dbo.Posts");
            DropTable("dbo.PostComments");
        }
    }
}
