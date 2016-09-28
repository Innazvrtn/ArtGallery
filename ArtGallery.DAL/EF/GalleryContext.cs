using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ArtGallery.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;



namespace ArtGallery.DAL.EF
{
    public class GalleryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }   
        static string _connection;
        public GalleryContext()
    : base(_connection ?? "GalleryArt")
{
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GalleryContext, ArtGallery.DAL.Migrations.Configuration>());
        }
        public GalleryContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GalleryContext, ArtGallery.DAL.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany(c => c.Tags)
                .WithMany(s => s.Posts)
                .Map(t => t.MapLeftKey("PostId")
                .MapRightKey("TagId")
                .ToTable("PostTag"));
            base.OnModelCreating(modelBuilder);
        }
    }

}

