using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
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
            AddTestViewModel viewModel = GetViewModelWithCityList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Test(AddTestViewModel model)
        {
            var isUnique = _context.Test.Any(x => x.City.CityName == model.CityName && x.DateOfTest == model.DateOfTest);
            if (isUnique)
            {
                ModelState.AddModelError(string.Empty, "Toks testas jau yra sukurtas");
            }

            var dateCheckInteger = DateTime.Today.CompareTo(model.DateOfTest.Date);
            if (dateCheckInteger == 1)
            {
                ModelState.AddModelError(string.Empty, "Data negali būti ankstesnė negu šiandiena");
            }

            if (ModelState.IsValid)
            {
                City city = _context.Cities.FirstOrDefault(x => x.CityName == model.CityName);
                if (city != null)
                {
                    Test newRecord = new Test() { City = city, DateOfTest = model.DateOfTest };
                    _context.Test.Add(newRecord);
                    _context.SaveChanges();

                    return RedirectToAction("List");
                }
            }
            AddTestViewModel viewModel = GetViewModelWithCityList();

            return View(viewModel);
        }

        public IActionResult List()
        {
             IEnumerable<AddTestViewModel> data = _context.Test.Select(x =>
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

        private AddTestViewModel GetViewModelWithCityList()
        {
            var data = _context.Cities.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();

            var viewModel = new AddTestViewModel() { Cities = data, DateOfTest = DateTime.Today };
            return viewModel;
        }
    }
}
