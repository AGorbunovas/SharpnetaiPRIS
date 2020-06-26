using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
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
                var newRecord = new City() { CityName = city.CityName};
                _context.Cities.Add(newRecord);
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

        #region TestResultSettings/Create

        public IActionResult TestResultLimits_View()  
        {
            return View(/*_context.TestResultLimits.ToList()*/);
        }

        [HttpGet]
        public IActionResult TestResultLimits_Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TestResultLimits_Create(AddTestResultSettingsViewModel limits) 
        {
            var check = _context.TestResultLimits.Any(x => x.ResultSettingsId == limits.ResultSettingsId);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Toks miestas jau yra sukurtas");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newRecord = new TestResultSettings() { ResultSettingsId = limits.ResultSettingsId, Task1 = limits.Task1, Task2 = limits.Task2, Task3 = limits.Task3, Task4 = limits.Task4, Task5 = limits.Task5, Task6 = limits.Task6, Task7 = limits.Task7, Task8 = limits.Task8, Task9 = limits.Task9, Task10 = limits.Task10, Task11 = limits.Task11, Task12 = limits.Task12, Task13 = limits.Task13, Task14 = limits.Task14 };
                _context.TestResultLimits.Add(newRecord);
                _context.SaveChanges();

                return RedirectToAction("TestResultLimits_View");
            }
            return View();
        }


        #endregion

    }
}