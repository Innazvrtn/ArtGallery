namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUserComent = c.Int(nullable: false),
                        Text = c.String(),
                        Mark = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IdPost = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Photo = c.Binary(),
                        Discription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostTagWeek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPost = c.Int(nullable: false),
                        IdTag = c.Int(nullable: false),
                        Post_Id = c.Int(),
                        Tag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .ForeignKey("dbo.Tag", t => t.Tag_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextTag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTagWeek", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.PostTagWeek", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropIndex("dbo.PostTagWeek", new[] { "Tag_Id" });
            DropIndex("dbo.PostTagWeek", new[] { "Post_Id" });
            DropIndex("dbo.Comment", new[] { "Post_Id" });
            DropTable("dbo.Tag");
            DropTable("dbo.PostTagWeek");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
