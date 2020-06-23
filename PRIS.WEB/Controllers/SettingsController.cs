using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PRIS.WEB.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult City()
        {
            return View();
        }
        
        public IActionResult Modules()
        {
            return View();
        }
        
        public IActionResult TestResultSetting()
        {
            return View();
        }

    }
}