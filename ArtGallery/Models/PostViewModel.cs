using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            ImageList = new List<string>();
            Tags = new List<TagViewModel>();
        }
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Photo { get; set; }
        public string Discription { get; set; }
        public List<string> ImageList { get; set; }
        public virtual ICollection<TagViewModel> Tags { get; set; }
  
    }
}