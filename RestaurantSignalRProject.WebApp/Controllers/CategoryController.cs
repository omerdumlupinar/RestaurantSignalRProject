using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantSignalRProject.WebApp.Dtos.CategoryDtos;
using System.Text;

namespace RestaurantSignalRProject.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateCategoryDtos createCategoryDtos)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDtos);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responsMessage = await client.PostAsync("https://localhost:44350/api/Category/CreateCategory", content);

            if (responsMessage.IsSuccessStatusCode)
            {
                
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id )
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:44350/api/Category/DeleteCategory/?id={id}");

            if (responsMessage.IsSuccessStatusCode)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:44350/api/Category/CategoryList");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDtos>>(jsonData);
               return Json(values);
            }
            return Json("");
        }
             


    }
}
