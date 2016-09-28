using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.DAL.Entities;

namespace ArtGallery.DAL.Interfaces
{
  public  interface IClientManager: IDisposable
    {
        void Create(ClientProfile item);
        ClientProfile Get(string id);
    }
}
