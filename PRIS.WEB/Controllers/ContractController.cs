using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels.ContractViewModule;

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

            var data = _context.Candidates.Where(x => candidateByCity.Contains(x.TestId) && x.Test.AcademicYearID == _context.Test.Max(t => t.AcademicYearID)).Select(x =>
            new CandidateContractViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                FirstModule = x.CandidateModules.Select(t => t.Module.ModuleName).FirstOrDefault(),
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                TestResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value),
                InterviewResult = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault(),
                GeneralResult = (_context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value) + _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault()) / 2,
                GeneralInterviewComment = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.GeneralComment).FirstOrDefault(),
                InvitedToStudy = x.InvitedToStudy,
                //ContractDate = _context.Contracts.Where(t => t.CandidateID == x.CandidateID).Select(t => t.ContractDate).FirstOrDefault(),
                //ContractType = _context.Contracts.Where(t => t.CandidateID == x.CandidateID).Select(t => t.ContractType).FirstOrDefault(),
                IsContractSigned = _context.Contracts.Where(t => t.CandidateID == x.CandidateID).Select(t => t.IsContractSigned).FirstOrDefault(),
            }).OrderByDescending(x => x.InvitedToStudy).ThenByDescending(x => x.GeneralResult).ToList();

            ViewBag.Cities = _context.Cities.Select(i => new SelectListItem()
            {
                Value = i.CityName,
                Text = i.CityName
            }).ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Contracts(IEnumerable<CandidateContractViewModel> model)
        {
            foreach (var item in model)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(candidate);
                candidate.InvitedToStudy = item.InvitedToStudy;
                _context.SaveChanges();
                TempData["CandidateInvitedToStudyInContractsUpdated"] = "Jūsų pasirinkimas išsaugotas";
            }
            return RedirectToAction("Contracts");
        }

        [HttpGet]
        public IActionResult ContractsSigned()
        {
            var data = _context.Candidates.Where(x => x.InvitedToStudy == true && x.Test.AcademicYearID == _context.Test.Max(t => t.AcademicYearID)).Select(x =>
            new CandidateContractViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                FirstModule = x.CandidateModules.Select(t => t.Module.ModuleName).FirstOrDefault(),
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                GeneralResult = (_context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value) + _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault()) / 2,
                GeneralInterviewComment = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.GeneralComment).FirstOrDefault(),
                AcademicYear = x.Test.AcademicYear.AcademicYearStart.ToString("yyyy-MM-dd") + "  ||  " + x.Test.AcademicYear.AcademicYearEnd.ToString("yyyy-MM-dd"),
                ContractDate = x.Contract.ContractDate,
                ContractType = x.Contract.ContractType,
                IsContractSigned = x.Contract.IsContractSigned,
            }).OrderByDescending(x => x.IsContractSigned).ThenByDescending(x => x.GeneralResult).ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult ContractsSigned(int id, CandidateContractViewModel contractModel)
        {
            DateTime timeStamp = DateTime.Now;
            if (!_context.Contracts.Any(c => c.CandidateID == id))
            {
                var candidateContract = new Contract()
                {
                    CandidateID = contractModel.CandidateID,
                    IsContractSigned = contractModel.IsContractSigned,
                    ContractDate = timeStamp,
                    ContractType = contractModel.ContractType
                };
                _context.Contracts.Add(candidateContract);
                _context.SaveChanges();
            }

            IEnumerable<CandidateContractViewModel> contractModelEnumerable = (IEnumerable<CandidateContractViewModel>)contractModel;

            foreach (var item in contractModelEnumerable)
            {
                Contract contract = _context.Contracts.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(contract);
                contract.IsContractSigned = item.IsContractSigned;
                _context.SaveChanges();
                TempData["CandidateInvitedToInterviewUpdated"] = "Jūsų pasirinkimas išsaugotas";
                return RedirectToAction("ContractsSigned");
            }
            return RedirectToAction("ContractsSigned");
        }
    }
}