namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "IdUserComment", c => c.String());
            DropColumn("dbo.Comment", "IdUserComent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "IdUserComent", c => c.String());
            DropColumn("dbo.Comment", "IdUserComment");
        }
    }
}
