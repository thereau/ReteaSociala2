namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageAndConversation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.String(nullable: false, maxLength: 128),
                        SecondUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FirstUserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.SecondUserId, cascadeDelete: false)
                .Index(t => t.FirstUserId)
                .Index(t => t.SecondUserId);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ConversationId = c.Int(nullable: false),
                    Text = c.String(),
                    userTurn = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .Index(t => t.ConversationId);

        }
       
        public override void Down()
        {
            DropForeignKey("dbo.Conversations", "SecondUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.Conversations", "FirstUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ConversationId" });
            DropIndex("dbo.Conversations", new[] { "SecondUserId" });
            DropIndex("dbo.Conversations", new[] { "FirstUserId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Conversations");
        }
    }
}
