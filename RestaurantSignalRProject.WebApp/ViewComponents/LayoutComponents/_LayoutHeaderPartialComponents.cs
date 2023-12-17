using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
