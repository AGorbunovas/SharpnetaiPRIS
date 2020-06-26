using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.TestViewModels;
using System.Linq;

namespace PRIS.WEB.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private AddTestViewModel viewModel;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
            //To do refactor
            var data = _context.Cities.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();
            viewModel = new AddTestViewModel() { Cities = data };
        }

        public IActionResult Test()
        {
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Test(AddTestViewModel model)
        {
            var check = _context.Test.Any(x => x.City.CityName == model.CityName && x.DateOfTest == model.DateOfTest);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Toks testas jau yra sukurtas");
            }
            if (ModelState.IsValid)
            {
                var city = _context.Cities.FirstOrDefault(x => x.CityName == model.CityName);
                var newRecord = new Test() { City = city, DateOfTest = model.DateOfTest };
                _context.Test.Add(newRecord);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();

            return View(viewModel);
        }

        public IActionResult List()
        {
             var data = _context.Test.Select(x =>
             new AddTestViewModel()
             {
                 DateOfTest = x.DateOfTest,
                 City = x.City,
                 TestId = x.TestId
             }).OrderByDescending(x => x.DateOfTest)
               .ToList();

            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Test.SingleOrDefault(x => x.TestId == id);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
