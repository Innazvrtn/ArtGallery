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
        PostDTO GetPost(int? id);
        void CreateComment(CommentDTO commentDTO);
        UserDTO Get(string id);
        IEnumerable<PostDTO> GetAllPost(string userId);
        IEnumerable<CommentDTO> GetAllComment(int postId);
        IEnumerable<PostDTO> FindPost(string name);
        IEnumerable<TagDTO> GetTagWithName(string text);
        void Dispose();
    }
}
