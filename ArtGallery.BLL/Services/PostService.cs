 using System;
using ArtGallery.BLL.DTO;
using ArtGallery.DAL.Entities;
using ArtGallery.DAL.Interfaces;
using ArtGallery.BLL.Infrastructure;
using ArtGallery.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Infrastructure.ConfigurationAutoMapperBLL;


namespace ArtGallery.BLL.Services
{
    public class PostService : IPostService
    {
        private IMapper _userMap;
        IUnitOfWork Database { get; set; }
        public PostService(IUnitOfWork uow)
        {
            Database = uow;
            _userMap = GetMapper();
        }
        public void CreatePost(PostDTO postDto)
        {


            var post = _userMap.Map<Post>(postDto);
            Database.Posts.Create(post);
            Database.Save();
        }
        public void CreateComment(CommentDTO commentDto)
        {
            Post post = Database.Posts.Get(commentDto.PostId);

            Comment com = new Comment
            {
                PostId = post.Id,
                Text = commentDto.Text,
                IdUserComment = commentDto.IdUserComment,
                Mark = commentDto.Mark,
                Date = commentDto.Date

            };
            Database.Comments.Create(com);
            Database.Save();


        }
        public PostDTO GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException(" id post=null", "");
            var post = Database.Posts.Get(id.Value);
            if (post == null)
                throw new ValidationException("Post not found", "");
            return _userMap.Map<PostDTO>(post);
        }
        public UserDTO Get(string id)
        {
            var user = Database.ClientManager.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ClientProfile, UserDTO>());
            return Mapper.Map<ClientProfile, UserDTO>(user);
        }
        public IEnumerable<PostDTO> GetAllPost(string userId)
        {
            var posts = Database.Posts.GetAll().Where(p => p.ClientId == userId);
            return _userMap.Map<List<PostDTO>>(posts);
        }
        public IEnumerable<PostDTO> FindPost(string name)
        {
            var tagList = Database.Tags.GetAll().Where(t => t.TextTag == name).Select(tg => tg.TextTag).ToList();
            var posts = Database.Posts.GetAll().Where(tg => tg.Tags.Any(tk => tagList.Contains(tk.TextTag)));
            return _userMap.Map<List<PostDTO>>(posts);
        }
        public IEnumerable<TagDTO> GetTagWithName(string text)
        {
            var tag = Database.Tags.GetAll().Where(p => p.TextTag == text);
            return _userMap.Map<List<TagDTO>>(tag);
        }

        public IEnumerable<CommentDTO> GetAllComment(int postId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetAll().Where(p => p.PostId == postId));
        }

        public void Dispose()
        {
            Database.Dispose();
        }



    }
}
