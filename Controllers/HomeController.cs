using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Controllers
{
    public class HomeController : Controller
    { 
        [Authorize]
        public IActionResult Home()
        {

            return View();
        }
    }
}
