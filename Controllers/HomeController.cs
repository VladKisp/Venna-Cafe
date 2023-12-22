using WebAppLab.Services.EmailServices;
using WebLabApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Resources;
using WebLabApp.web.Models;

namespace WebLabApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ISender _emailSender;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(ILogger<HomeController> logger, ISender emailSender, IStringLocalizer<HomeController> localizer)
		{
			_logger = logger;
			_emailSender=emailSender;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var model = new LanguageSelectionModel
            {
                AvailableCultures = new[] { "en-US", "uk-UA" }, // Add other cultures if needed
                CurrentCulture = System.Globalization.CultureInfo.CurrentCulture.Name
            };

            return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> SendEmail([FromBody] EmailModel vm)
		{
			var _vm = vm;
			if (_vm == null)
			{
				return BadRequest();
			}
			await _emailSender.SendEmailAsync(_vm.Email, "Test", _vm.MessageText);
			return Ok();
		}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LanguagePartial()
        {
            var model = new List<string> { "en", "uk" };
            return PartialView("_LanguageSwitcher", model);
        }
    }
}