using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.BookingDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("BookingList")]
        public IActionResult BookingList()
        {
            var resultAboutDtos = _mapper.Map<List<ResultAboutDto>>(_bookingService.TGetListAll());
            return Ok(resultAboutDtos);
        }

        [HttpGet]
        [Route("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var getBookingDto = _mapper.Map<List<GetBookingDto>>(_bookingService.TGetById(id));
            return Ok(getBookingDto);
        }

        [HttpPost]
        [Route("CreateBooking")]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var booking = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var booking = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteBooking")]
        public IActionResult DeleteBooking(int id)
        {
            var entity = _bookingService.TGetById(id);
            _bookingService.TDelete(entity);
            return Ok("Rezervasyon silme işlemi başarılı.");
        }
    }
}
