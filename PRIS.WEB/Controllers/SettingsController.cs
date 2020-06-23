using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.Models;

namespace PRIS.WEB.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
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


        [HttpPost]
        public IActionResult City(City city)  
        {
            _context.City.Add(city);
            _context.SaveChanges();

            return View();
        }
        
        public IActionResult Modules()
        {
            return View();
        }
        
        public IActionResult TestResultSettings() 
        {
            return View();
        }

    }
}