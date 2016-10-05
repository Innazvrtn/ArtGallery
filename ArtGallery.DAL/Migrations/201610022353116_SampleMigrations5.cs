namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "Mark", c => c.Int());
            AlterColumn("dbo.Comment", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comment", "Mark", c => c.Int(nullable: false));
        }
    }
}
