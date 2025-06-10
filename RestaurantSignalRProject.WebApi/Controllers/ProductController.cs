using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSignalRProject.BusinessLayer.Abstract;
using RestaurantSignalRProject.DtoLayer.AboutDto;
using RestaurantSignalRProject.DtoLayer.CategoryDto;
using RestaurantSignalRProject.DtoLayer.ProductDto;
using RestaurantSignalRProject.EntityLayer.Entities;

namespace RestaurantSignalRProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ProductList")]
        public IActionResult ProductList()
        {
            GetProductDto getProductDto = _mapper.Map<GetProductDto>(_productService.TGetListAll());
            return Ok(getProductDto);
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            GetProductDto getProductDto = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            return Ok(getProductDto);
        }

        [HttpPost]
        [Route("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            var resultProductDtos = _mapper.Map<List<ResultProductsWithCategories>>(_productService.GetProductsWithCategories());
            return Ok(resultProductDtos);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Hakkımızda ekleme işlemi başarılı.");
        }

        [HttpPut]
        [Route("CreateAbout")]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            Product product = _mapper.Map<Product>(updateAboutDto);
            _productService.TUpdate(product);
            return Ok("Hakkımızda güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        [Route("DeleteAbout")]
        public IActionResult DeleteAbout(int id)
        {
            var entity = _productService.TGetById(id);
            _productService.TDelete(entity);
            return Ok("Hakkımızda silme işlemi başarılı.");
        }
    }
}
