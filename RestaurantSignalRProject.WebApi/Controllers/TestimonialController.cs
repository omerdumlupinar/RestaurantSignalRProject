using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DataAccessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.TestimonialDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("TestimonialList")]
        public IActionResult TestimonialList()
        {
            var resultTestimonialDto = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(resultTestimonialDto);
        }

        [HttpGet]
        [Route("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var getTestimonialDto = _mapper.Map<List<GetTestimonialDto>>(_testimonialService.TGetById(id));
            return Ok(getTestimonialDto);
        }

        [HttpPost]
        [Route("CreateTestimonial")]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Müşteri yorum ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateTestimonial")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonial);
            return Ok("Müşteri yorum güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteTestimonial")]
        public IActionResult DeleteTestimonial(int id)
        {
            var entity = _testimonialService.TGetById(id);
            _testimonialService.TDelete(entity);
            return Ok("Müşteri yorum silme işlemi başarılı.");
        }
    }
}
