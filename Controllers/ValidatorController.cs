using Microsoft.AspNetCore.Mvc;
using WebLabApp.web.Models;

namespace WebLabApp.web.Controllers
{
    public class ValidatorController : Controller
    {
        public IActionResult Validator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ValidationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Validator");
        }
    }
}
