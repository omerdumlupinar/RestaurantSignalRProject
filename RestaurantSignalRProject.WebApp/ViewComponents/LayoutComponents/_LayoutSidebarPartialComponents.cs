using Microsoft.AspNetCore.Mvc;

namespace RestaurantSignalRProject.WebApp.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponents:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
