using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Candidate()
        {
            AddCandidateViewModel viewModel = GetViewModelWithModulesList();

            return View("Candidate", viewModel);
        }

        [HttpPost]
        public IActionResult Candidate(AddCandidateViewModel model)
        {
            
            AddCandidateViewModel viewModel = GetViewModelWithModulesList();

            return View(viewModel);
        }

        private AddCandidateViewModel GetViewModelWithModulesList()
        {
            var modules = _context.Modules.Select(x => new SelectListItem()
            {
                Value = x.ModuleID.ToString(),
                Text = x.ModuleName
            }).ToList();

            var tests = _context.Test.Select(x => new SelectListItem()
            {
                Value = x.TestId.ToString(),
                Text = x.DateOfTest + " " + x.City.CityName
            }).ToList();

            var viewModel = new AddCandidateViewModel() { SelectedModuleIds = new int?[] { null, null, null }, Modules = modules, Tests = tests };
            return viewModel;
        }
    }
}
