using AutoMapper;
using RestaurantSignalRProject.DtoLayer.CategoryDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
                CreateMap<Category,CreateCategoryDto>().ReverseMap();
                CreateMap<Category,UpdateCategoryDto>().ReverseMap();
                CreateMap<Category,ResultCategoryDto>().ReverseMap();
                CreateMap<Category,GetCategoryDto>().ReverseMap();
        }
    }
}
