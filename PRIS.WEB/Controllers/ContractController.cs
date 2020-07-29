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
using PRIS.WEB.ViewModels.CandidateViewModels;
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

            var candidateByModule = new List<int>();
            if (module != null)
            {
                candidateByModule = _context.CandidateModules.Where(x => x.OrderNr == 0 && x.ModuleID == module.ModuleID).Select(x => x.CandidateID).ToList();
            }
            else
            {
                candidateByModule = _context.CandidateModules.Select(x => x.CandidateID).ToList();
            }

            var data = _context.Candidates.Where(x => candidateByCity.Contains(x.TestId) && candidateByModule.Contains(x.CandidateID) && x.Test.AcademicYearID == _context.Test.Max(t => t.AcademicYearID) && x.InvitedToInterview == true).Select(x =>
            new CandidateContractViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                FirstModule = x.CandidateModules.OrderBy(t => t.OrderNr).Select(t => t.Module.ModuleName).FirstOrDefault(),
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                TestResult = _context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value),
                InterviewResult = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault(),
                GeneralResult = (_context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value) + _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault()) / 2,
                GeneralInterviewComment = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.GeneralComment).FirstOrDefault(),
                InvitedToStudy = x.InvitedToStudy,
                IsContractSigned = x.IsContractSigned,
            }).OrderByDescending(x => x.InvitedToStudy).ThenByDescending(x => x.GeneralResult).ToList();

            ViewBag.Cities = _context.Cities.Select(i => new SelectListItem()
            {
                Value = i.CityName,
                Text = i.CityName
            }).ToList();

            ViewBag.Modules = _context.Modules.Select(i => new SelectListItem()
            {
                Value = i.ModuleName,
                Text = i.ModuleName
            }).ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Contracts(IEnumerable<CandidateContractViewModel> contractModel)
        {
            foreach (var item in contractModel)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(candidate);
                candidate.InvitedToStudy = item.InvitedToStudy;
                _context.SaveChanges();
                TempData["CandidateInvitedToStudyInContractsUpdated"] = "Jūsų pasirinkimas išsaugotas";
            }
            return RedirectToAction("Contracts");
        }


        public IActionResult ContractsSigned(string City, string Module)
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

            var candidateByModule = new List<int>();
            if (module != null)
            {
                candidateByModule = _context.CandidateModules.Where(x => x.OrderNr == 0 && x.ModuleID == module.ModuleID).Select(x => x.CandidateID).ToList();
            }
            else
            {
                candidateByModule = _context.CandidateModules.Select(x => x.CandidateID).ToList();
            }

            var data = _context.Candidates.Where(x => candidateByCity.Contains(x.TestId) && candidateByModule.Contains(x.CandidateID) && x.Test.AcademicYearID == _context.Test.Max(t => t.AcademicYearID) && x.InvitedToStudy == true).Select(x =>
            new CandidateContractViewModel()
            {
                CandidateID = x.CandidateID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                FirstModule = x.CandidateModules.OrderBy(t => t.OrderNr).Select(t => t.Module.ModuleName).FirstOrDefault(),
                TestDate = x.Test.DateOfTest,
                TestCity = x.Test.City.CityName,
                GeneralResult = (_context.TaskResult.Where(t => t.CandidateId == x.CandidateID).Sum(t => t.Value) + _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.Value).FirstOrDefault()) / 2,
                GeneralInterviewComment = _context.InterviewResults.Where(t => t.CandidateId == x.CandidateID).Select(t => t.GeneralComment).FirstOrDefault(),
                AcademicYear = x.Test.AcademicYear.AcademicYearStart.ToString("yyyy-MM-dd") + "  ||  " + x.Test.AcademicYear.AcademicYearEnd.ToString("yyyy-MM-dd"),
                ContractDate = x.Contract.ContractDate,
                ContractType = x.Contract.ContractType,
                IsContractSigned = x.IsContractSigned,
            }).OrderByDescending(x => x.IsContractSigned).ThenByDescending(x => x.GeneralResult).ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult ContractsSigned(IEnumerable<CandidateContractViewModel> contractModel)
        {
            foreach (var item in contractModel)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                _context.Attach(candidate);
                candidate.IsContractSigned = item.IsContractSigned;
                _context.SaveChanges();
                TempData["CandidateInvitedToStudyInContractsUpdated"] = "Jūsų pasirinkimas išsaugotas";
            }

            foreach (var item in contractModel)
            {
                if (!item.IsContractSigned)
                {
                    if (_context.Contracts.Any(c => c.CandidateID == item.CandidateID))
                    {
                        Contract contractToDelete = _context.Contracts.FirstOrDefault(x => x.CandidateID == item.CandidateID);
                        _context.Contracts.Remove(contractToDelete);
                        _context.SaveChanges();
                    }
                };

                DateTime timeStamp = DateTime.Now;
                if (!_context.Contracts.Any(c => c.CandidateID == item.CandidateID))
                {
                    var candidateContract = new Contract()
                    {
                        CandidateID = item.CandidateID,
                        ContractDate = timeStamp,
                        ContractType = item.ContractType
                    };
                    _context.Contracts.Add(candidateContract);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ContractsSigned");
        }

        //[HttpPost]
        //public IActionResult ContractsSigned(CandidateContractViewModel contractModel)
        //{
        //    DateTime timeStamp = DateTime.Now;
        //    if (!_context.Contracts.Any(c => c.CandidateID == contractModel.CandidateID))
        //    {
        //        if (!contractModel.IsContractSigned)
        //        {
        //            var contractToDelete = _context.Contracts.Where(x => x.CandidateID == contractModel.CandidateID).FirstOrDefault();
        //            _context.Contracts.Remove(contractToDelete);
        //            _context.SaveChanges();
        //        };
        //        var candidateContract = new Contract()
        //        {
        //            CandidateID = contractModel.CandidateID,
        //            IsContractSigned = contractModel.IsContractSigned,
        //            ContractDate = timeStamp,
        //            ContractType = contractModel.ContractType
        //        };
        //        _context.Contracts.Add(candidateContract);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("ContractsSigned");
        //}

    }
}