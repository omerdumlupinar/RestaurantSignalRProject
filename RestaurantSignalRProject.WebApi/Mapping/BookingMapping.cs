using AutoMapper;
using RestaurantSignalRProject.DtoLayer.BookingDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
                CreateMap<Booking,CreateBookingDto>().ReverseMap();
                CreateMap<Booking,UpdateBookingDto>().ReverseMap();
                CreateMap<Booking,GetBookingDto>().ReverseMap();
                CreateMap<Booking,ResultBookingDto>().ReverseMap();
        }
    }
}
