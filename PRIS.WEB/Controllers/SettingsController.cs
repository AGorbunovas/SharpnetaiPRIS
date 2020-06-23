using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Models;

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
        
        public IActionResult City()
        {
            return View();
        }

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
        #endregion

        public IActionResult TestResultSettings() 
        {
            return View();
        }

    }
}