namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugacoloane : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AdressName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AccountCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
