using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.ModuleViewModels;
using PRIS.WEB.ViewModels.TaskGroupViewModel;
using PRIS.WEB.ViewModels.ResultLimitViewModel;
using System;
using System.Linq;

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
            if (TempData["TestIsAddedToTheCityErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["TestIsAddedToTheCityErrorMessage"].ToString());
            }
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
                TempData["TestIsAddedToTheCityErrorMessage"] = "Miesto trinti negalima - jam jau yra priskirtas testas.";
                return RedirectToAction("City");
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

        #endregion City/Create/Delete

        #region Module

        public IActionResult Module()
        {
            if (TempData["IsTestUsedInCandidateModuleTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInCandidateModuleTableErrorMessage"].ToString());
            }
            return View("Module", _context.Modules.OrderBy(m => m.ModuleName).ToList());
        }

        #endregion Module

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

        public IActionResult ModuleDelete(int id)
        {
            var testConnected = _context.CandidateModules.Any(x => x.Module.ModuleID == id);

            if (testConnected)
            {
                TempData["IsTestUsedInCandidateModuleTableErrorMessage"] = "Negalima trinti mokymo programos, nes ji yra priskirta prie kandidato!";
                return RedirectToAction("Module");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Modules.SingleOrDefault(x => x.ModuleID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return RedirectToAction("Module");
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
        public IActionResult ResultLimits_Create(ResultMaxLimitViewModel limits)
        {
            //TODO rezultatu limitai susije su testo sablonu
            decimal sumTestResults = 0;

            for (int i = 0; i < limits.TestTasks.Count; i++)
            {
                sumTestResults += (decimal)limits.TestTasks[i].MaxResultLimit;
            }

            
            if (ModelState.IsValid)
            {
                string timeStamp = GetTimestamp(DateTime.Now);
                var newRecord = new ResultLimit() { 
                    ResultLimitsId = limits.ResultLimitsId, 
                    DateLimitSet = timeStamp, 
                    TestTasks = limits.TestTasks
                };
                if (newRecord != null)
                {
                    _context.ResultLimits.Add(newRecord);
                    _context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Įveskite teisingus duomenis.");
                }
                return RedirectToAction("ResultLimits_View");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Pasitikrinkite, ar įvedėte visus duomenis.");
            }
            return View();
        }

        private string GetTimestamp(DateTime date)
        {
            return date.Date.ToString("yyyy/MM/dd");
        }

        //#endregion ResultLimits/Create
    }
}