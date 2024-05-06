namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Phone", c => c.String());
            AlterColumn("dbo.Reservations", "Email", c => c.String());
            AlterColumn("dbo.Reservations", "Name", c => c.String());
        }
    }
}
