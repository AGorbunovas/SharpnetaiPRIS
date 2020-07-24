using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.CandidateViewModels;

namespace PRIS.WEB.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Contracts(string City, string Module) 
        {
            City city = _context.Cities.FirstOrDefault(x => x.CityName == City);
            Module module = _context.Modules.FirstOrDefault(x => x.ModuleName == Module);

            var candidateByCity = new List<int>();

            if (city != null)
            {
                candidateByCity = _context.Test.Where(x => x.CityId == city.CityId).Select(x => x.TestId).ToList();
            }
            else
            {
                candidateByCity = _context.Test.Select(x => x.TestId).ToList();
            }

            var data = _context.Candidates.Where(y => candidateByCity.Contains(y.TestId)).Select(x =>
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
    }
}