namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "IsRead");
        }
    }
}
