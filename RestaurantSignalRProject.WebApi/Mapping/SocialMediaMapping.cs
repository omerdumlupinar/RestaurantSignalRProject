using AutoMapper;
using RestaurantSignalRProject.DtoLayer.SocialMediaDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
                CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,UpdateSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
                CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap();
        }
    }
}
