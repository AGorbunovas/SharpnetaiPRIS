using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Migrations;
using PRIS.WEB.Models;
using Module = PRIS.WEB.Models.Module;

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
            return View();
        }

        #region City/Create
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
        public IActionResult CityModalPartial(City city) 
        {
            var check = _context.Cities.Any(x => x.CityName == city.CityName);

            if (check)
            {
                ModelState.AddModelError("Error message", "Toks miestas jau yra sukurtas");
                return View();
            }

            else if (ModelState.IsValid)
            {
                _context.Cities.Add(city);
                _context.SaveChanges();

                return RedirectToAction("City");
            }
            return View();
        }

        public IActionResult CityDelete(int id) 
        {
            //TODO - patikrinti, ar miestui priskirtas testas
            var data = _context.Cities.SingleOrDefault(x => x.CityId == id);
            _context.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("City");
        }
        #endregion

        #region Module/Create

        public async Task<IActionResult> Module()
        {
            return View(await _context.Modules.ToListAsync());
        }

        public IActionResult ModuleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModuleCreate(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
            return RedirectToAction("Module");
        }

        #endregion Module/Create

        #region Module/Delete

        public async Task<IActionResult> ModuleDelete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var module = await _context.Modules
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(module => module.ModuleID == id);
            if (module == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
            }
            return View(module);
        }

        [HttpPost, ActionName("ModuleDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModuleDeleteConfirmed(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return RedirectToAction("Module");
            }
            try
            {
                _context.Modules.Remove(module);
                await _context.SaveChangesAsync();

                return RedirectToAction("Module");
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction("ModuleDelete", new { id = id, saveChangesError = true });
            }
        }

        #endregion Module/Delete

        public IActionResult TestResultSettings() 
        {
            return View();
        }

    }
}