namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostToTag", "PostId", "dbo.Post");
            DropForeignKey("dbo.PostToTag", "TagId", "dbo.Tag");
            DropIndex("dbo.PostToTag", new[] { "PostId" });
            DropIndex("dbo.PostToTag", new[] { "TagId" });
            DropTable("dbo.PostToTag");
            DropTable("dbo.Tag");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextTag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostToTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PostToTag", "TagId");
            CreateIndex("dbo.PostToTag", "PostId");
            AddForeignKey("dbo.PostToTag", "TagId", "dbo.Tag", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostToTag", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
    }
}
