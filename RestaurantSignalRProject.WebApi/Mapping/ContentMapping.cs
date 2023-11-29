using AutoMapper;
using RestaurantSignalRProject.DtoLayer.ContentDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class ContentMapping : Profile
    {
        public ContentMapping()
        {
                CreateMap<Content,CreateContentDto>().ReverseMap();
                CreateMap<Content,UpdateContentDto>().ReverseMap();
                CreateMap<Content,GetContentDto>().ReverseMap();
                CreateMap<Content,ResultContentDto>().ReverseMap();
        }
    }
}
