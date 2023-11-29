using AutoMapper;
using RestaurantSignalRProject.DtoLayer.DiscountDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
                CreateMap<Discount,CreateDiscountDto>().ReverseMap();
                CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
                CreateMap<Discount,ResultDiscountDto>().ReverseMap();
                CreateMap<Discount,GetDiscountDto>().ReverseMap();
        }
    }
}
