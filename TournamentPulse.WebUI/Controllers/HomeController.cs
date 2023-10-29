using Localization.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TournamentPulse.Infrastructure.Data.Generator;
using TournamentPulse.WebUI.Models;

namespace TournamentPulse.WebUI.Controllers
{

    public class HomeController : Controller
    {
        private static class Constants
        {
            public const string WelcomeMessage = "str_welcome_message";
        }

        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;

        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = _localization.Getkey(Constants.WelcomeMessage);
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Academies()
        {
            return View();
        }

        public IActionResult Associations()
        {
            return View();
        }

        public IActionResult Athletes()
        {
            return View();
        }

        #region Localization
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}