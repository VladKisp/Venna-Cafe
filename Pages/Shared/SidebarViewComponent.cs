using Microsoft.AspNetCore.Mvc;

public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}