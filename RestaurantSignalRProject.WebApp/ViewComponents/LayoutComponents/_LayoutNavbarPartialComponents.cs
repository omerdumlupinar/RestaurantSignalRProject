using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
