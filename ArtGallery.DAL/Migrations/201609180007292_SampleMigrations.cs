namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.PostTagWeek", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.PostTagWeek", "Tag_Id", "dbo.Tag");
            DropIndex("dbo.Comment", new[] { "Post_Id" });
            DropIndex("dbo.PostTagWeek", new[] { "Post_Id" });
            DropIndex("dbo.PostTagWeek", new[] { "Tag_Id" });
            RenameColumn(table: "dbo.Comment", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.PostTagWeek", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.PostTagWeek", name: "Tag_Id", newName: "TagId");
            AlterColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.PostTagWeek", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.PostTagWeek", "TagId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            CreateIndex("dbo.PostTagWeek", "PostId");
            CreateIndex("dbo.PostTagWeek", "TagId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostTagWeek", "PostId", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostTagWeek", "TagId", "dbo.Tag", "Id", cascadeDelete: true);
            DropColumn("dbo.Comment", "IdPost");
            DropColumn("dbo.PostTagWeek", "IdPost");
            DropColumn("dbo.PostTagWeek", "IdTag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostTagWeek", "IdTag", c => c.Int(nullable: false));
            AddColumn("dbo.PostTagWeek", "IdPost", c => c.Int(nullable: false));
            AddColumn("dbo.Comment", "IdPost", c => c.Int(nullable: false));
            DropForeignKey("dbo.PostTagWeek", "TagId", "dbo.Tag");
            DropForeignKey("dbo.PostTagWeek", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.PostTagWeek", new[] { "TagId" });
            DropIndex("dbo.PostTagWeek", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.PostTagWeek", "TagId", c => c.Int());
            AlterColumn("dbo.PostTagWeek", "PostId", c => c.Int());
            AlterColumn("dbo.Comment", "PostId", c => c.Int());
            RenameColumn(table: "dbo.PostTagWeek", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.PostTagWeek", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "Post_Id");
            CreateIndex("dbo.PostTagWeek", "Tag_Id");
            CreateIndex("dbo.PostTagWeek", "Post_Id");
            CreateIndex("dbo.Comment", "Post_Id");
            AddForeignKey("dbo.PostTagWeek", "Tag_Id", "dbo.Tag", "Id");
            AddForeignKey("dbo.PostTagWeek", "Post_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Comment", "Post_Id", "dbo.Post", "Id");
        }
    }
}
