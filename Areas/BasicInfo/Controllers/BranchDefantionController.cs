using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class BranchDefantionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
