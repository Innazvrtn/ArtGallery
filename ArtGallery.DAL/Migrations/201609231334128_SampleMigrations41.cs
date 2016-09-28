namespace ArtGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations41 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Post", name: "Client_Id", newName: "ClientId");
            RenameIndex(table: "dbo.Post", name: "IX_Client_Id", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Post", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameColumn(table: "dbo.Post", name: "ClientId", newName: "Client_Id");
        }
    }
}
