using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string IdUserComment { get; set; }
        public string Text { get; set; }
        public int? Mark { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
    }
}