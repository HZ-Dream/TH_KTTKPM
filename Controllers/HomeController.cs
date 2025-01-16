using ASCWeb.Configuration;
using ASCWeb.Models;
using ASCWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ASCWeb.Controllers
{
	public class HomeController : Controller
	{
		private IOptions<ApplicationSettings> _setting;

		public HomeController(IOptions<ApplicationSettings> settings)
		{
			_setting = settings;
		}

		public IActionResult Index([FromServices] IEmailSender emailSender)
		{
			var emailService = this.HttpContext.RequestServices.GetService(typeof(IEmailSender)) as IEmailSender;
			ViewBag.Title = _setting.Value.ApplicationTitle;
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Dashboard()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
