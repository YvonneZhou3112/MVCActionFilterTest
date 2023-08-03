namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Age");
        }
    }
}
