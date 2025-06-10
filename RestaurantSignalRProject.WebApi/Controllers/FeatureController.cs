using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.FeatureDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("FeatureList")]
        public IActionResult FeatureList()
        {
            var resultDiscountDto = _mapper.Map<List<ResultFetureDto>>(_featureService.TGetListAll());
            return Ok(resultDiscountDto);
        }

        [HttpGet]
        [Route("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var getFeatureDto = _mapper.Map<List<GetFeatureDto>>(_featureService.TGetById(id));
            return Ok(getFeatureDto);
        }

        [HttpPost]
        [Route("CreateFeature")]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(feature);
            return Ok("Öne çıkan ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateFeature")]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(feature);
            return Ok("Öne çıkan güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteFeature")]
        public IActionResult DeleteFeature(int id)
        {
            var entity = _featureService.TGetById(id);
            _featureService.TDelete(entity);
            return Ok("Öne çıkan silme işlemi başarılı.");
        }
    }
}
