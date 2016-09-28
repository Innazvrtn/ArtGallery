using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ArtGallery.DAL.Entities
{
    [Table("Post")]
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public virtual ClientProfile Client { get; set; }
        public string Photo { get; set; }
        public string Discription { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public Post()
        {
            Tags = new List<Tag>();
        }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
