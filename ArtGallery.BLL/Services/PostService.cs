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

namespace ArtGallery.BLL.Services
{
    public class PostService : IPostService
    {
        IUnitOfWork Database { get; set; }
        public PostService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreatePost(PostDTO postDto)
        {
             Post post = new Post
            {
                
                 ClientId = postDto.ClientId,
                 Discription = postDto.Discription,
                 Photo = postDto.Photo,
                               
             };
            Database.Posts.Create(post);
            Database.Save();
        }
        public void CreateComment(CommentDTO commentDto)
        {
            Comment com = new Comment
            {
                PostId=commentDto.PostId,
                Text = commentDto.Text

            };


        }

        public IEnumerable<PostDTO> GetAllPost(string userId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Post, PostDTO>());
            return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(Database.Posts.GetAll().Where(p => p.ClientId == userId));
        }
        public IEnumerable<PostDTO> FindPost(string name)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Post, PostDTO>());
            return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(Database.Posts.GetAll().Where(p => p.Discription == name));
            
        }
        public IEnumerable<TagDTO> GetTagWithName(string text)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Tag, TagDTO>());
            return Mapper.Map<IEnumerable<Tag>, List<TagDTO>>(Database.Tags.GetAll().Where(p => p.TextTag == text));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void CreateTag(TagDTO tagDto)
        {
            throw new NotImplementedException();
        }
    }
}
