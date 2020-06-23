using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.Models;

namespace PRIS.WEB.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(Test test)
        {
            _context.Test.Add(test);
            _context.SaveChanges();

            return View();
        }
    }
}