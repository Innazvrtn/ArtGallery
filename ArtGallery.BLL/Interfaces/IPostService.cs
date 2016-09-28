using ArtGallery.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostDTO postDto);
        void CreateTag(TagDTO tagDto);
        void CreateComment(CommentDTO commentDTO);
        IEnumerable<PostDTO> GetAllPost(string userId);
        IEnumerable<PostDTO> FindPost(string name);
        IEnumerable<TagDTO> GetTagWithName(string text);
        void Dispose();
    }
}
