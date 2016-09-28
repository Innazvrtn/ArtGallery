namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigration21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Post", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Post", "Photo", c => c.Binary());
        }
    }
}
