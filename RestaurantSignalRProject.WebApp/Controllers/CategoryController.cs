using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
