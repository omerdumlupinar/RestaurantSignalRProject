    using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
