using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
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

        public IActionResult Interviews(string City, string Module)
        {
            City city = _context.Cities.FirstOrDefault(x => x.CityName == City);

            var candidateByCity = new List<int>();

            if (city != null)
            {
                candidateByCity = _context.Test.Where(x => x.DateOfTest == _context.Test.Max(x => x.DateOfTest) && x.CityId == city.CityId).Select(x => x.TestId).ToList();
            }
            else
            {
                candidateByCity = _context.Test.Where(x=> x.DateOfTest == _context.Test.Max(x => x.DateOfTest)).Select(x => x.TestId).ToList();
            }

            var data = _context.Candidates.Where(y => y.InvitedToInterview == true && candidateByCity.Contains(y.TestId)).Select(x =>
            new ListCandidateViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                TestResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value),
                FirstModule = x.CandidateModules.Select(t => t.Module.ModuleName).FirstOrDefault(),
                InvitedToInterview = x.InvitedToInterview,
                InvitedToStudy = x.InvitedToStudy
            }).OrderByDescending(x => x.TestResult).ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Interviews(IEnumerable<ListCandidateViewModel> model)
        {
            foreach (var item in model)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(candidate);
                candidate.InvitedToStudy = item.InvitedToStudy;
                _context.SaveChanges();
                TempData["CandidateInvitedToStudyUpdated"] = "Jūsų pasirinkimas išsaugotas";
            }
            return RedirectToAction("Interviews");
        }


        public IActionResult AddInterviewData()
        {
            return View();
            //return RedirectToAction("Interviews");
        }
    }
}