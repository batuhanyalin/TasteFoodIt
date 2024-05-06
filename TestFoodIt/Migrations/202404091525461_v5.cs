namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "IconCircleColor", c => c.String());
            DropColumn("dbo.Notifications", "IconColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "IconColor", c => c.String());
            DropColumn("dbo.Notifications", "IconCircleColor");
        }
    }
}
