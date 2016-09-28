namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "UserId", c => c.String());
        }
    }
}
