using ArtGallery.DAL.Interfaces;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ArtGallery.DAL.Repositories
{
   public class CommentRepository : IRepository<Comment>
    {
        private GalleryContext db;

        public CommentRepository(GalleryContext context)
        {
            this.db = context;
        }
        public void Create(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
                db.Comments.Remove(comment);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return db.Comments.Include(o => o.Post).Where(predicate).ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.Include(o => o.Post);
        }

        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }
    }
}
