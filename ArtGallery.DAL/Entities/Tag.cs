using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.DAL.Entities
{
    [Table("Tag")]
    public class Tag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string TextTag { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public Tag()
        {
            Posts = new List<Post>();
        }


    }
}
