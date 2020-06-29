using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.ModuleViewModels;

namespace PRIS.WEB.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ApplicationDbContext _context;

        public SettingsController(ILogger<SettingsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Settings()
        {
            return RedirectToAction("City");
        }

        #region City/Create/Delete
        public IActionResult City()
        {
            return View(_context.Cities.ToList());
        }

        [HttpGet]
        public IActionResult CityModalPartial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CityModalPartial(AddCityViewModel city)
        {
            var check = _context.Cities.Any(x => x.CityName == city.CityName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Toks miestas jau yra sukurtas");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newRecord = new City() { CityName = city.CityName };
                if (newRecord != null)
                {
                    _context.Cities.Add(newRecord);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return View();
        }
        public IActionResult CityDelete(int id)
        {
            var testConnected = _context.Test.Any(x => x.City.CityId == id);

            if (testConnected)
            {
                ViewData["ErrorMessage"] = "Miesto trinti negalima - jam jau yra priskirtas testas.";
                return View();
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Cities.SingleOrDefault(x => x.CityId == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return RedirectToAction("City");
        }
        #endregion

        #region Module
        public IActionResult Module()
        {
            return View(_context.Modules.ToList());
        }
        #endregion

        #region Module/Create
        public IActionResult ModuleCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModuleCreate(AddModuleViewModel module)
        {
            var check = _context.Modules.Any(m => m.ModuleName == module.ModuleName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Tokia mokymų programa jau yra sukurta");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newModule = new Module() { ModuleName = module.ModuleName };
                if (newModule != null)
                {
                    _context.Modules.Add(newModule);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return View();
        }

        #endregion Module/Create

        #region Module/Delete

        public IActionResult ModuleDelete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var moduleData = _context.Modules
                .SingleOrDefault(module => module.ModuleID == id);

            if (moduleData == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
            }
            return View(moduleData);
        }

        [HttpPost, ActionName("ModuleDelete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ModuleDeleteConfirmed(int? id)
        {
            var moduleData = await _context.Modules.FindAsync(id);
            if (moduleData == null)
            {
                return RedirectToAction("Module");
            }
            try
            {
                _context.Modules.Remove(moduleData);
                await _context.SaveChangesAsync();

                return RedirectToAction("Module");
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction("ModuleDelete", new { id = id, saveChangesError = true });
            }
        }

        #endregion Module/Delete

        #region ResultLimits/Create

        public IActionResult ResultLimits_View()
        {
            return View(_context.ResultLimits.ToList());
        }

        [HttpGet]
        public IActionResult ResultLimits_Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResultLimits_Create(AddResultLimitsViewModel limits)
        {

            if (ModelState.IsValid)
            {
                string timeStamp = GetTimestamp(DateTime.Now.Date);
                var newRecord = new ResultLimits() { ResultLimitsId = limits.ResultLimitsId, DateLimitSet = timeStamp, Task1 = limits.Task1, Task2 = limits.Task2, Task3 = limits.Task3, Task4 = limits.Task4, Task5 = limits.Task5, Task6 = limits.Task6, Task7 = limits.Task7, Task8 = limits.Task8, Task9 = limits.Task9, Task10 = limits.Task10};
                _context.ResultLimits.Add(newRecord);
                _context.SaveChanges();

                return RedirectToAction("ResultLimits_View");
            }
            return View();
        }

        private string GetTimestamp(DateTime date)
        {
            return date.ToString();
        }


        #endregion

    }
}