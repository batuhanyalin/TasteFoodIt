namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailId);
            
            AddColumn("dbo.Notifications", "IconColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "IconColor");
            DropTable("dbo.Mails");
        }
    }
}
