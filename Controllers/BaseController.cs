<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ASCWeb.Controllers
{
    public class BaseController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASCWeb.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
      
       
>>>>>>> 9d3b72e (Fix Lab 4)
    }
}
