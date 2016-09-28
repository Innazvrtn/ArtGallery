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
    public class TagRepository : IRepository<Tag>
    {
        private GalleryContext db;

        public TagRepository(GalleryContext context)
        {
            this.db = context;
        }

        public void Create(Tag tag)
        {
            db.Tags.Add(tag);
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Tags.Remove(tag);
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return db.Tags.Where(predicate).ToList();
        }

        public Tag Get(int id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public void Update(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
        }
    }
}
