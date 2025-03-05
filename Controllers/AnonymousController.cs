using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ASCWeb.Controllers
{
    public class AnonymousController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
