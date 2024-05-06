namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DateDifferent", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "DateDifferent");
        }
    }
}
