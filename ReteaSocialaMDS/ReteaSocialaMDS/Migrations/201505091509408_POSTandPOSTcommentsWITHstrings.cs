namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POSTandPOSTcommentsWITHstrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "PostCommentMessage", c => c.String());
            AddColumn("dbo.Posts", "PostMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostMessage");
            DropColumn("dbo.PostComments", "PostCommentMessage");
        }
    }
}
