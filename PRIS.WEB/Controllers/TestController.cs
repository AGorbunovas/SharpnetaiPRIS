using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using System.Linq;

namespace PRIS.WEB.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Test model;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
            //To do
            var data = _context.Cities.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();

            model = new Test() { Cities = data };
        }

        public IActionResult Test()
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Test(Test test)
        {
            var check = _context.Test.Any(x => x.City == test.City && x.DateOfTest == test.DateOfTest);

            if(check)
            {
                ModelState.AddModelError(string.Empty, "Toks testas jau yra sukurtas");
            }

            if (ModelState.IsValid)
            {
                _context.Test.Add(test);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            return View(model);
        }

        public IActionResult List()
        {
            var data = _context.Test.OrderByDescending(x => x.DateOfTest).ToList();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Test.Where(x => x.TestId == id).SingleOrDefault();
            _context.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

    }
}