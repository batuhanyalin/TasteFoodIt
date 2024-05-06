namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Namesurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Namesurname");
        }
    }
}
