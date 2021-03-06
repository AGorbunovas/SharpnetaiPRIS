﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Logic;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.CandidateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRIS.WEB.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ICandidateTestResultProcessor _candidateTestResultProcessor;

        public CandidateController(ApplicationDbContext context, ICandidateTestResultProcessor candidateTestResultProcessor)
        {
            _context = context;
            _candidateTestResultProcessor = candidateTestResultProcessor;
        }

        [HttpGet("Candidate/Edit/{id}")]
        public IActionResult EditCandidate(int id)
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
                  InvitedToStudy = x.InvitedToStudy,
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

        public IActionResult List(string City)
        {
            var newestTest = new List<int>();

            City city = _context.Cities.FirstOrDefault(x => x.CityName == City);
            if (city != null)
            {
                newestTest = _context.Test.Where(x => x.DateOfTest == _context.Test.Max(x => x.DateOfTest) && x.CityId == city.CityId).Select(x => x.TestId).ToList();
            }
            else
            {
                newestTest = _context.Test.Where(x => x.DateOfTest == _context.Test.Max(x => x.DateOfTest)).Select(x => x.TestId).ToList();
            }

            var data = _context.Candidates.Where(c => newestTest.Contains(c.TestId)).Select(x =>
            new ListCandidateViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                FirstModule = x.CandidateModules.OrderBy(t => t.OrderNr).Select(t => t.Module.ModuleName).FirstOrDefault(),
                TestResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value),
                MaxResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.TaskResultLimit.MaxValue),
                InvitedToInterview = x.InvitedToInterview,
                InvitedToStudy = x.InvitedToStudy
            }).OrderByDescending(x => x.TestResult).ToList();

            ViewBag.Cities = _context.Cities.Select(i => new SelectListItem()
            {
                Value = i.CityName,
                Text = i.CityName
            }).ToList();

            if (TempData["NotAllCandidatesHaveTastResultsBeforeInvitingToInterview"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["NotAllCandidatesHaveTastResultsBeforeInvitingToInterview"].ToString());
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult List(IEnumerable<ListCandidateViewModel> model)
        {
            foreach (var item in model)
            {
                if (!_context.TaskResult.Any(x => x.CandidateId == item.CandidateID) && item.InvitedToInterview == true)
                {
                    TempData["NotAllCandidatesHaveTastResultsBeforeInvitingToInterview"] = $"Negalima kviesti kandidatų į pokalbį, jei nėra įvesti testo balai";
                    return RedirectToAction("List");
                }
            }

            foreach (var item in model)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(candidate);
                candidate.InvitedToInterview = item.InvitedToInterview;
                _context.SaveChanges();
            }
            TempData["CandidateInvitedToInterviewUpdated"] = "Kandidatai pokalbiui patvirtinti";
            return RedirectToAction("List");
        }

        [HttpPost("Candidate/Edit/{id}")]
        public IActionResult EditCandidate(int id, AddCandidateViewModel model)
        {
            if (!model.SelectedModuleIds.Any(x => x > 0))
            {
                ModelState.AddModelError("SelectedModuleIds", "Kandidatui turi būti pasirinkta bent viena mokymosi programa");
            }

            if (ModelState.IsValid)
            {
                var record = _context.Candidates.Include(t => t.CandidateModules).Where(t => t.CandidateID == id).Single();

                record.FirstName = model.Firstname;
                record.LastName = model.Lastname;
                record.Gender = model.Gender;
                record.Email = model.Email;
                record.PhoneNumber = model.Phone.Value;
                record.Comment = model.Comment;
                record.TestId = model.TestId.Value;
                record.InvitedToStudy = model.InvitedToStudy;

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
            if (!model.SelectedModuleIds.Any(x => x > 0))
            {
                ModelState.AddModelError("SelectedModuleIds", "Kandidatui turi būti pasirinkta bent viena mokymosi programa");
            }

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
                    TestId = model.TestId.Value,
                    InvitedToStudy = model.InvitedToStudy,
                    CandidateModules = model.SelectedModuleIds.Where(t => t.HasValue).Distinct().Select((t, i) => new CandidateModule() { OrderNr = i, ModuleID = t.Value }).ToList()
                };
                _context.Candidates.Add(newRecord);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            return View(viewModel);
        }


        [HttpGet("Candidate/AddTaskResult/{id}")]
        public IActionResult AddTaskResult(int id)
        {
            TaskResultViewModel model = new TaskResultViewModel();
            var candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == id);

            if (candidate == null || candidate.InvitedToInterview == true)
            {

                return RedirectToAction("List");
            }

            model.Candidate = candidate;

            if (_context.TaskResult.Any(c => c.Candidate == candidate))
            {
                model.Value = _context.TaskResult.Where(c => c.Candidate == model.Candidate).Select(x => x.Value).ToList();
                model.TaskGroupName = _context.TaskResult.Where(c => c.Candidate == model.Candidate).Select(x => x.TaskResultLimit.TaskGroup.TaskGroupName).ToList();
            }
            else
            {
                List<TaskResultLimit> currentTestResultLimits = _context.TaskResultLimits.OrderByDescending(x => x.Date).Take(10).ToList();

                for (int i = 0; i < 10; i++)
                {
                    model.Value.Add(0.0);
                    int TaskGroupID = currentTestResultLimits[i].TaskGroupID;
                    string TaskGroupName = _context.TaskGroups.Where(x => x.TaskGroupID == TaskGroupID).Select(x => x.TaskGroupName).FirstOrDefault();
                    model.TaskGroupName.Add(TaskGroupName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddTaskResult(TaskResultViewModel model, int id)
        {
            model.Candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == id);
            var CandidateHasTaskResults = _context.TaskResult.Any(x => x.Candidate == model.Candidate);

            if (CandidateHasTaskResults)
            {
                var candidateTaskResults = _context.TaskResult.Where(x => x.Candidate == model.Candidate).ToList();
                var candidateTestResultsLimits = _context.TaskResult.Where(x => x.Candidate == model.Candidate).Select(x => x.TaskResultLimit).ToList();
                model.TaskGroupName = _context.TaskResult.Where(c => c.Candidate == model.Candidate).Select(x => x.TaskResultLimit.TaskGroup.TaskGroupName).ToList();

                var validationResultMessage = _candidateTestResultProcessor.ValidateTestResultsToTestResultLimits(candidateTestResultsLimits, model);

                if (validationResultMessage != null)
                {
                    ModelState.AddModelError(string.Empty, validationResultMessage);
                    return View(model);
                }

                _candidateTestResultProcessor.UpdateExistingCandidateResults(model, _context, candidateTaskResults);
            }
            else
            {
                List<TaskResultLimit> currentTestResultLimits = _context.TaskResultLimits.OrderByDescending(x => x.Date).Take(10).ToList();
                model.TaskGroupName = _context.TaskResultLimits.OrderByDescending(x => x.Date).Select(x => x.TaskGroup.TaskGroupName.ToString()).Take(10).ToList();

                var validationResultMessage = _candidateTestResultProcessor.ValidateTestResultsToTestResultLimits(currentTestResultLimits, model);

                if (validationResultMessage != null)
                {

                    ModelState.AddModelError(string.Empty, validationResultMessage);
                    return View(model);
                }

                _candidateTestResultProcessor.SaveInitialCandidateResults(model, currentTestResultLimits, _context);
            }

            return RedirectToAction("List");
        }


        private AddCandidateViewModel GetViewModelWithModulesList(AddCandidateViewModel viewModel = null)
        {
            if (viewModel == null) viewModel = new AddCandidateViewModel() { SelectedModuleIds = new int?[] { } };

            viewModel.Modules = _context.Modules.Where(x => x.ModuleName != null).Select(x => new SelectListItem()
            {
                Value = x.ModuleID.ToString(),
                Text = x.ModuleName
            }).ToList();

            viewModel.Tests = _context.Test.OrderByDescending(x => x.DateOfTest).Select(x => new SelectListItem()
            {
                Value = x.TestId.ToString(),
                Text = x.DateOfTest.ToString("yyyy-MM-dd") + " " + x.City.CityName
            }).ToList();

            var ids = viewModel.SelectedModuleIds.Take(3).ToList();
            while (ids.Count < 3)
                ids.Add(null);
            viewModel.SelectedModuleIds = ids.ToArray();

            viewModel.Modules.Insert(0, new SelectListItem());

            return viewModel;
        }
    }
}