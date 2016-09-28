using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.DAL.Interfaces;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.EF;

namespace ArtGallery.DAL.Repositories
{
    class ClientManager : IClientManager
    {
        public GalleryContext Database { get; set; }
        public ClientManager(GalleryContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public ClientProfile Get(string id)
        {
            return Database.ClientProfiles.Find(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
