using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.BLL.DTO
{
  public  class PostDTO
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Photo { get; set; }
        public string Discription { get; set; }
        public virtual ICollection<TagDTO> Tags { get; set; }
        public PostDTO()
        {
            Tags = new List<TagDTO>();
        }
    }
}
