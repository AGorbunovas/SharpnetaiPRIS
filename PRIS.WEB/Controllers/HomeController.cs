using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var NeedToChangedInitialPassword = user.ChangeInitialPassword;

            if (NeedToChangedInitialPassword)
            {
                TempData["NeedToChangedInitialPassword"] = "Prašome pakeisti pirminį slaptažodį.";
                return View();
            }

            return View("Index");
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(Test test)
        {
            return View();
        }

        public IActionResult Kandidatai()
        {
            return View();
        }

        public IActionResult Settings()
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
