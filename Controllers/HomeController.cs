using ASC.Ultilities;
using ASCWeb.Configuration;
using ASCWeb.Models;
using ASCWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ASCWeb.Controllers
{
	public class HomeController : AnonymousController
	{
		private IOptions<ApplicationSettings> _settings;

		public HomeController(IOptions<ApplicationSettings> settings)
		{
			_settings = settings;
		}

		public IActionResult Index()
		{
			HttpContext.Session.SetSession("Test", _settings.Value);
			var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");
            ViewBag.Title = _settings.Value.ApplicationTitle;
            return View();
        }

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";
			return View();
		}

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
