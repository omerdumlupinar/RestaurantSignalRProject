using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.ContentDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContentService _contentService;

        public ContentController(IMapper mapper, IContentService contentService)
        {
            _mapper = mapper;
            _contentService = contentService;
        }
        [HttpGet]
        [Route("ContentList")]
        public IActionResult ContentList()
        {
            GetContentDto getContentDto= _mapper.Map<GetContentDto>(_contentService.TGetListAll());
            return Ok(getContentDto);
        }

        [HttpGet]
        [Route("GetContent")]
        public IActionResult GetContent(int id)
        {
            GetContentDto getContentDto = _mapper.Map<GetContentDto>(_contentService.TGetById(id));
            return Ok(getContentDto);
        }

        [HttpGet]
        [Route("CreateContent")]
        public IActionResult CreateContent(CreateContentDto createContentDto)
        {
            Content content= _mapper.Map<Content>(createContentDto);
            _contentService.TAdd(content);
            return Ok("İletişim ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateContent")]
        public IActionResult UpdateContent(UpdateContentDto updateContentDto)
        {
            Content content = _mapper.Map<Content>(updateContentDto);
            _contentService.TUpdate(content);
            return Ok("İletişim güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteContent")]
        public IActionResult DeleteContent(int id)
        {
            var entity = _contentService.TGetById(id);
            _contentService.TDelete(entity);
            return Ok("İletişim silme işlemi başarılı.");
        }
    }
}
