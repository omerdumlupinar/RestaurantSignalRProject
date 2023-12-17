using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
