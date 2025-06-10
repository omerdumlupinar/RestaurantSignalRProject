using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.CategoryDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("CategoryList")]
        public IActionResult CategoryList()
        {
            var resultCategoryDto  = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(resultCategoryDto);
        }

        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var getCategoryDto = _mapper.Map<List<GetCategoryDto>>(_categoryService.TGetById(id));
            return Ok(getCategoryDto);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(category);
            return Ok("Kategory ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategory güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            var entity = _categoryService.TGetById(id);
            _categoryService.TDelete(entity);
            return Ok("Kategory silme işlemi başarılı.");
        }
    }
}
