namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostTagWeek", newName: "PostToTag");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PostToTag", newName: "PostTagWeek");
        }
    }
}
