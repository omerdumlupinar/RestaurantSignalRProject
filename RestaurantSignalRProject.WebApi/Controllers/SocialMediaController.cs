using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.SocialMediaDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMedia;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMedia, IMapper mapper)
        {
            _socialMedia = socialMedia;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("SocialMediaList")]
        public IActionResult SocialMediaList()
        {
            List<GetSocialMediaDto> getSocialMediaDto  = _mapper.Map<List<GetSocialMediaDto>>(_socialMedia.TGetListAll());
            return Ok(getSocialMediaDto);
        }

        [HttpGet]
        [Route("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            List<GetSocialMediaDto> getSocialMediaDto = _mapper.Map<List<GetSocialMediaDto>>(_socialMedia.TGetById(id));
            return Ok(getSocialMediaDto);
        }

        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto )
        {
            SocialMedia socialMedia  = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMedia.TAdd(socialMedia);
            return Ok("Sosyal Medya ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateSocialMedia")]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto )
        {
            SocialMedia socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMedia.TUpdate(socialMedia);
            return Ok("Sosyal Medya güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteSocialMedia")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var entity = _socialMedia.TGetById(id);
            _socialMedia.TDelete(entity);
            return Ok("Sosyal Medya silme işlemi başarılı.");
        }
    }
}
