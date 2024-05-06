namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IconColors",
                c => new
                    {
                        IconColorId = c.Int(nullable: false, identity: true),
                        IconColorText = c.String(),
                    })
                .PrimaryKey(t => t.IconColorId);
            
            AddColumn("dbo.Notifications", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "IconColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "IconId");
            CreateIndex("dbo.Notifications", "IconColorId");
            AddForeignKey("dbo.Notifications", "IconId", "dbo.Icons", "IconId", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "IconColorId", "dbo.IconColors", "IconColorId", cascadeDelete: true);
            DropColumn("dbo.Notifications", "Icon");
            DropColumn("dbo.Notifications", "IconCircleColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "IconCircleColor", c => c.String());
            AddColumn("dbo.Notifications", "Icon", c => c.String());
            DropForeignKey("dbo.Notifications", "IconColorId", "dbo.IconColors");
            DropForeignKey("dbo.Notifications", "IconId", "dbo.Icons");
            DropIndex("dbo.Notifications", new[] { "IconColorId" });
            DropIndex("dbo.Notifications", new[] { "IconId" });
            DropColumn("dbo.Notifications", "IconColorId");
            DropColumn("dbo.Notifications", "IconId");
            DropTable("dbo.IconColors");
        }
    }
}
