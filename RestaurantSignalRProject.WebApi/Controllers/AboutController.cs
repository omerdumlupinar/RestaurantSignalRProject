using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("AboutList")]
        public IActionResult AboutList()
        {
            List<GetAboutDto> getAboutDto = _mapper.Map<List<GetAboutDto>>(_aboutService.TGetListAll());
            return Ok(getAboutDto);
        }

        [HttpGet]
        [Route("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            List<GetAboutDto> getAboutDto = _mapper.Map<List<GetAboutDto>>(_aboutService.TGetById(id));
            return Ok(getAboutDto);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout( CreateAboutDto createAboutDto)
        {
            About about = _mapper.Map<About>(createAboutDto);
             _aboutService.TAdd(about);
            return Ok("Hakkımızda ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateAbout")]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteAbout")]
        public IActionResult DeleteAbout(int id)
        {
            var entity=_aboutService.TGetById(id);
            _aboutService.TDelete(entity);
            return Ok("Hakkımızda silme işlemi başarılı.");
        }
    }
}
