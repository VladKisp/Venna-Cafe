using Microsoft.AspNetCore.Mvc;

namespace WebLabApp.web.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
