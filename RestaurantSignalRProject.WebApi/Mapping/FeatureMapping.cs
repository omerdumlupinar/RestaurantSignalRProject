using AutoMapper;
using RestaurantSignalRProject.DtoLayer.FeatureDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,ResultFetureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
        }
    }
}
