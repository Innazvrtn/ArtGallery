using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.EF;
using ArtGallery.DAL.Interfaces;
using System.Data.Entity;

namespace ArtGallery.DAL.Repositories
{
   public class PostRepository : IRepository<Post>
    {
        private GalleryContext db;
        public PostRepository(GalleryContext context)
        {
            this.db = context;
        }
        public void Create(Post post)
        {
            db.Posts.Add(post);
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }

        public IEnumerable<Post> Find(Func<Post, bool> predicate)
        {
            return db.Posts.Where(predicate).ToList();
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public void Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }
    }
}
