using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.ResultLimitViewModel;
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

            return View("Test", viewModel);
        }

        [HttpPost]
        public IActionResult Test(AddTestViewModel model)
        {
            var isNotUnique = _context.Test.Any
                (
                x => x.City.CityName == model.CityName && x.DateOfTest == model.DateOfTest && x.ClassYearStart == model.ClassYearStart && x.ClassYearEnd == model.ClassYearEnd
                );

            if (isNotUnique)
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
                    Test newRecord = new Test() { City = city, DateOfTest = model.DateOfTest, ClassYearStart = model.ClassYearStart, ClassYearEnd = model.ClassYearEnd};
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
                TestId = x.TestId,
                ClassYearStart = x.ClassYearStart,
                ClassYearEnd = x.ClassYearEnd
            }).OrderByDescending(x => x.DateOfTest)
              .ToList();


            if (TempData["IsTestUsedInCandidateTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInCandidateTableErrorMessage"].ToString());
            }
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var test = _context.Test.SingleOrDefault(x => x.TestId == id);
            var IsTestUsedInCandidateTable = _context.Candidates.Any(x => x.Test == test);

            if (IsTestUsedInCandidateTable)
            {
                TempData["IsTestUsedInCandidateTableErrorMessage"] = "Negalima trinti testo, nes jis yra priskirtas prie kandidato!";
                return RedirectToAction("List");
            }

            if (test != null)
            {
                _context.Remove(test);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public IActionResult ResultLimitTA()
        {
            ResultLimitTAViewModel model = new ResultLimitTAViewModel();
            model.Value.Add(0);
            model.Value.Add(0);
            model.Value.Add(0);
            model.Value.Add(0);
            model.Value.Add(0);

            _context.ResultsTA.Select(x => x.ResultLimitTA.Value);

            return View(model);
        }

        [HttpPost]
        public IActionResult ResultLimitTA(ResultLimitTAViewModel model)
        {
            foreach (var item in model.Value)
            {
                var dbModel = new ResultLimitTA();
                dbModel.Date = DateTime.Today;
                dbModel.Position = item;
                dbModel.Value = item;

                _context.ResultLimitTA.Add(dbModel);
                _context.SaveChanges();
            }


            var candidate = new Candidate
            {
                FirstName = "Foo",
                LastName = "Bar",
                Email = "asas",
                PhoneNumber = 1111,
                Test = _context.Test.FirstOrDefault(x => x.TestId == 1)
            };

            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            var ResultLimitTA = new ResultLimitTA {
                Date = DateTime.Today,
                Value = 1
            };

            var result = new ResultsTA
            {
                Candidate = candidate,
                Result = 1,
                ResultLimitTA = ResultLimitTA

            };

            _context.ResultsTA.Add(result);
            _context.SaveChanges();

            return View(model);
        }



        private AddTestViewModel GetViewModelWithCityList()
        {
            var data = _context.Cities.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();

            var viewModel = new AddTestViewModel() { Cities = data, DateOfTest = DateTime.Today, ClassYearStart = DateTime.Today, ClassYearEnd = DateTime.Today.AddMonths(10) };
            return viewModel;
        }
    
    
    
    
    }
}