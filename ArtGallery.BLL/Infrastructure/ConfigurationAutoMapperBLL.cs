using AutoMapper;
using ArtGallery.BLL.DTO;
using ArtGallery.DAL.Entities;
using System.Linq;


namespace BLL.Infrastructure
{
    public static class ConfigurationAutoMapperBLL
    {

        private static MapperConfiguration _configMap;

        static ConfigurationAutoMapperBLL()
        {
            _configMap = new MapperConfiguration(fr =>
            {
                fr.CreateMap<Post, PostDTO>()
                    .ForMember(s => s.Tags, d => d.ResolveUsing(s => s.Tags)).ReverseMap()
                .ForMember(s => s.Tags, o => o.MapFrom(
                            s => s.Tags.Select(x => new TagDTO()
                            {
                                Id = x.Id,
                                TextTag = x.TextTag

                            }).ToList()))
                        .ReverseMap();
                fr.CreateMap<Tag, TagDTO>()
                .ForMember(s => s.Posts, o => o.MapFrom(
                               s => s.Posts.Select(x => new PostDTO()
                               {
                                   Id = x.Id,
                                   ClientId = x.ClientId,
                                   Discription = x.Discription,
                                   Photo = x.Photo

                               }).ToList()))
                            .ReverseMap()
                    .ForMember(s => s.Posts, d => d.ResolveUsing(s => s.Posts)).ReverseMap();
            });
        }
        public static Mapper GetMapper()
        {
            return new Mapper(_configMap);
        }
    }
}
