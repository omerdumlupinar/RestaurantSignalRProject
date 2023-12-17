using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
