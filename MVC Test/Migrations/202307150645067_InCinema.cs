namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InCinema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "InCinema", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "InCinema");
        }
    }
}
