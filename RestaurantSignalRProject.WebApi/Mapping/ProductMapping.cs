using AutoMapper;
using RestaurantSignalRProject.DtoLayer.ProductDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
                CreateMap<Product,CreateProductDto>().ReverseMap();
                CreateMap<Product,UpdateProductDto>().ReverseMap();
                CreateMap<Product,ResultProductDto>().ReverseMap();
                CreateMap<Product,GetProductDto>().ReverseMap();
        }
    }
}
