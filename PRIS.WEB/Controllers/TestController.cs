using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using System.Linq;

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
            var data = _context.City.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();

            var model = new Test() { Cities = data };
            return View(model);
        }

        [HttpPost]
        public IActionResult Test(Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Test.Add(test);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            return View();
        }

        public IActionResult List()
        {
            var data = _context.Test.OrderByDescending(x => x.DateOfTest).ToList();

            return View(data);
        }
    }
}