using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Models;

namespace PRIS.WEB.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(Test test)
        {
            return View();
        }
    }
}