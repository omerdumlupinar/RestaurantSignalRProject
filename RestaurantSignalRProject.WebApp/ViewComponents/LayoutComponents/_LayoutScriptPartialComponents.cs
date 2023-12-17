using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.ViewComponents.LayoutComponents
{
    public class _LayoutScriptPartialComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                return View();
        }
    }
}
