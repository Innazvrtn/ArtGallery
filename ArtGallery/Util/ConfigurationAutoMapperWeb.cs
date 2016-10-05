using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ArtGallery.BLL.DTO;
using ArtGallery.Models;

namespace ArtGallery.Util
{
    public static class ConfigurationAutoMapperWeb
    {
        private static MapperConfiguration _configMap;

        static ConfigurationAutoMapperWeb()
        {
            _configMap = new MapperConfiguration(fr =>
            { 
           fr.CreateMap<PostDTO, PostViewModel>()
                .ForMember(s => s.Tags, o => o.MapFrom(
                                s => s.Tags.Select(x => new TagDTO()
                                {
                                    Id = x.Id,
                                    TextTag = x.TextTag

                                }).ToList()))
                            .ReverseMap()
              .ForMember(s => s.Tags, d => d.ResolveUsing(s => s.Tags)).ReverseMap();
                fr.CreateMap<TagDTO, TagViewModel>()
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
