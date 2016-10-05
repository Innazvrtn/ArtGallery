using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string TextTag { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }

    }
}