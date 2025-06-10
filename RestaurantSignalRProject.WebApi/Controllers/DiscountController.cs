using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.DiscountDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;

        public DiscountController(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            _discountService = discountService;
        }
        [HttpGet]
        [Route("DiscountList")]
        public IActionResult DiscountList()
        {
            var resultDiscountDto = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(resultDiscountDto);
        }

        [HttpGet]
        [Route("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var getDiscountDto = _mapper.Map<List<GetDiscountDto>>(_discountService.TGetById(id));
            return Ok(getDiscountDto);
        }

        [HttpPost]
        [Route("CreateDiscount")]
        public IActionResult CreateDiscount(CreateAboutDto createAboutDto)
        {
            var discount  = _mapper.Map<Discount>(createAboutDto);
            _discountService.TAdd(discount);
            return Ok("İndirim ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("CreateAbout")]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var discount = _mapper.Map<Discount>(updateAboutDto);
            _discountService.TUpdate(discount);
            return Ok("İndirim güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteDiscount")]
        public IActionResult DeleteDiscount(int id)
        {
            var entity = _discountService.TGetById(id);
            _discountService.TDelete(entity);
            return Ok("İndirim silme işlemi başarılı.");
        }
    }
}
