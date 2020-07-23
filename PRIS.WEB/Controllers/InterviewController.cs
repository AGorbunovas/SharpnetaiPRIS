using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.ViewModels.CandidateViewModels;

namespace PRIS.WEB.Controllers
{
    public class InterviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InterviewController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Interviews()
        {
            var data = _context.Candidates.Select(x =>
            new ListCandidateViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                TestResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value),
                FirstModule = x.CandidateModules.Select(t => t.Module.ModuleName).FirstOrDefault()
            }).OrderByDescending(x => x.TestResult).ToList();
            return View(data);
        }
    }
}