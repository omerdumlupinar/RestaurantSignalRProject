using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantSignalRProject.WebApp.Dtos.CategoryDtos;

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

            var client=_httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:44350/api/Category/CategoryList");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData=await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
