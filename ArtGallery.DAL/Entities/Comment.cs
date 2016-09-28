using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace ArtGallery.DAL.Entities
{
    [Table("Comment")]
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string IdUserComent { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }


    }
}
