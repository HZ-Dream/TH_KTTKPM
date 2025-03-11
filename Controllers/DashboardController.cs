using ASCWeb.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASCWeb.Controllers
{
    public class DashboardController : BaseController
    {
        private IOptions<ApplicationSettings> _settings;
<<<<<<< HEAD

        public DashboardController(IOptions<ApplicationSettings> settings)
=======
        public DashboardController(IOptions<ApplicationSettings> settings) 
>>>>>>> 9d3b72e (Fix Lab 4)
        {
            _settings = settings;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
