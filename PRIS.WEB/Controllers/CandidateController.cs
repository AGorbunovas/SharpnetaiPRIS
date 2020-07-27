using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.CandidateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRIS.WEB.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Candidate(int id)
        {
            var data = _context.Candidates.Where(t => t.CandidateID == id).Select(x =>
              new AddCandidateViewModel()
              {
                  CandidateID = x.CandidateID,
                  Firstname = x.FirstName,
                  Lastname = x.LastName,
                  Comment = x.Comment,
                  Email = x.Email,
                  Gender = x.Gender,
                  SelectedModuleIds = x.CandidateModules.OrderBy(t=>t.OrderNr).Select(t => (int?)t.ModuleID).ToArray(),
                  Phone = x.PhoneNumber,
                  TestId = x.TestId
              }).Single();

            AddCandidateViewModel viewModel = GetViewModelWithModulesList(data);

            return View("Candidate", viewModel);
        }

        public IActionResult Candidate()
        {
            AddCandidateViewModel viewModel = GetViewModelWithModulesList();

            return View("Candidate", viewModel);
        }

        public IActionResult List()
        {
            var data = _context.Candidates.Select(x =>
            new ListCandidateViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                FirstModule = x.CandidateModules.OrderBy(t => t.OrderNr).Select(t => t.Module.ModuleName).FirstOrDefault()
            }).ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Candidates.SingleOrDefault(x => x.CandidateID == id);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }

        [HttpPost("{id}")]
        public IActionResult Candidate(int id, AddCandidateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var record = _context.Candidates.Include(t => t.CandidateModules).Where(t => t.CandidateID == id).Single();

                record.FirstName = model.Firstname;
                record.LastName = model.Lastname;
                record.Gender = model.Gender;
                record.Email = model.Email;
                record.PhoneNumber = model.Phone.Value;
                record.Comment = model.Comment;
                record.TestId = model.TestId;

                var selectedModules = model.SelectedModuleIds.Distinct().ToArray();

                var removeModules = record.CandidateModules.Where(t => !selectedModules.Contains(t.ModuleID)).ToArray();
                foreach (var removeModule in removeModules)
                    record.CandidateModules.Remove(removeModule);

                var newModules = selectedModules.Where(t => t.HasValue).Where(t => !record.CandidateModules.Select(tt => tt.ModuleID).Contains(t.Value))
                    .Select(x => new CandidateModule() { CandidateID = id, ModuleID = x.Value }).ToArray();
                foreach (var newModule in newModules)
                    record.CandidateModules.Add(newModule);

                for (var i = 0; i < selectedModules.Length; i++)
                {
                    var module = record.CandidateModules.Where(t => t.ModuleID == model.SelectedModuleIds[i]).FirstOrDefault();
                    if (module != null)
                    {
                        module.OrderNr = i;
                    }
                }

                _context.SaveChanges();
                return RedirectToAction("List");
            }

            AddCandidateViewModel viewModel = GetViewModelWithModulesList(model);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Candidate(AddCandidateViewModel model)
        {
            AddCandidateViewModel viewModel = GetViewModelWithModulesList(model);

            if (model.SelectedModuleIds[0] == null)
            {
                ModelState.AddModelError("SelectedModulesAreNotDistinct", "Pasirinkite pirmąją mokymosi programą");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                Candidate newRecord = new Candidate()
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    Email = model.Email,
                    Gender = model.Gender,
                    PhoneNumber = model.Phone.Value,
                    Comment = model.Comment,
                    TestId = model.TestId,
                    CandidateModules = model.SelectedModuleIds.Where(t => t.HasValue).Distinct().Select((t, i) => new CandidateModule() { ModuleID = t.Value, OrderNr = i }).ToList()
                };
                _context.Candidates.Add(newRecord);
                _context.SaveChanges();

                return RedirectToAction("List");
            }



            return View(viewModel);
        }

        private AddCandidateViewModel GetViewModelWithModulesList(AddCandidateViewModel viewModel = null)
        {
            if (viewModel == null) viewModel = new AddCandidateViewModel() { SelectedModuleIds = new int?[] { } };

            viewModel.Modules = _context.Modules.Where(x => x.ModuleName != null).Select(x => new SelectListItem()
            {
                Value = x.ModuleID.ToString(),
                Text = x.ModuleName
            }).ToList();

            viewModel.Tests = _context.Test.Select(x => new SelectListItem()
            {
                Value = x.TestId.ToString(),
                Text = x.DateOfTest.ToString("yyyy-MM-dd") + " " + x.City.CityName
            }).ToList();

            if (viewModel.SelectedModuleIds.Length < viewModel.Modules.Count)
            {
                var ids = viewModel.SelectedModuleIds.ToList();
                while (ids.Count < viewModel.Modules.Count)
                    ids.Add(null);
                viewModel.SelectedModuleIds = ids.ToArray();
            }

            viewModel.Modules.Insert(0, new SelectListItem());

            return viewModel;
        }
    }
}
