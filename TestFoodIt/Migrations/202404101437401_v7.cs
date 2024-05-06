namespace TestFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Notifications", "IconColorId", "dbo.IconColors");
            DropIndex("dbo.Notifications", new[] { "IconId" });
            DropIndex("dbo.Notifications", new[] { "IconColorId" });
            AddColumn("dbo.Notifications", "Icon", c => c.String());
            AddColumn("dbo.Notifications", "IconColor", c => c.String());
            DropColumn("dbo.Notifications", "IconId");
            DropColumn("dbo.Notifications", "IconColorId");
            DropTable("dbo.IconColors");
            DropTable("dbo.Icons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        IconId = c.Int(nullable: false, identity: true),
                        IconText = c.String(),
                    })
                .PrimaryKey(t => t.IconId);
            
            CreateTable(
                "dbo.IconColors",
                c => new
                    {
                        IconColorId = c.Int(nullable: false, identity: true),
                        IconColorText = c.String(),
                    })
                .PrimaryKey(t => t.IconColorId);
            
            AddColumn("dbo.Notifications", "IconColorId", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "IconId", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "IconColor");
            DropColumn("dbo.Notifications", "Icon");
            CreateIndex("dbo.Notifications", "IconColorId");
            CreateIndex("dbo.Notifications", "IconId");
            AddForeignKey("dbo.Notifications", "IconColorId", "dbo.IconColors", "IconColorId", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "IconId", "dbo.Icons", "IconId", cascadeDelete: true);
        }
    }
}
