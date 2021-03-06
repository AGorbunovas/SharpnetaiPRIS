﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
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

            return View("Test", viewModel);
        }

        [HttpPost]
        public IActionResult Test(AddTestViewModel model)
        {
            var isNotUnique = _context.Test.Any
                (
                    x => x.City.CityName == model.CityName && x.DateOfTest == model.DateOfTest
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
                AcademicYear academicYear = _context.AcademicYears.Find(model.AcademicYearID);

                if (city != null)
                {
                    Test newRecord = new Test() { City = city, DateOfTest = model.DateOfTest, AcademicYear = academicYear };
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
                AcademicYear = _context.AcademicYears.FirstOrDefault(a => a.AcademicYearID == x.AcademicYearID)
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

        private AddTestViewModel GetViewModelWithCityList()
        {
            var data = _context.Cities.Select(x => new SelectListItem()
            {
                Value = x.CityName,
                Text = x.CityName
            }).ToList();

            var academicYear = _context.AcademicYears.OrderByDescending(x => x.AcademicYearID).Select(i => new SelectListItem()
            {
                Value = i.AcademicYearID.ToString(),
                Text = i.AcademicYearStart.ToString("yyyy-MM-dd") + "  ||  " + i.AcademicYearEnd.ToString("yyyy-MM-dd")
            }).ToList();

            var viewModel = new AddTestViewModel() { Cities = data, DateOfTest = DateTime.Today, AcademicYears = academicYear };
            return viewModel;
        }
    }
}