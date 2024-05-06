namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "DateDifferent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "DateDifferent", c => c.DateTime(nullable: false));
        }
    }
}
