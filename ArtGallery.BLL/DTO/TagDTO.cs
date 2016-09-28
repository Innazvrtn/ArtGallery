using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.BLL.DTO
{
  public  class TagDTO
    {
        public int Id { get; set; }
        public string TextTag { get; set; }
        public virtual ICollection<PostDTO> Posts { get; set; }
        public TagDTO()
        {
            Posts = new List<PostDTO>();
        }
    }
}
