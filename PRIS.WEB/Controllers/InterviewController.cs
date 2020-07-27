using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Logic;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.CandidateViewModels;

namespace PRIS.WEB.Controllers
{
    public class InterviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ICandidateInterviewResultProcessor _candidateInterviewResultProcessor;

        public InterviewController(ApplicationDbContext context, ICandidateInterviewResultProcessor candidateInterviewResultProcessor)
        {
            _context = context;
            _candidateInterviewResultProcessor = candidateInterviewResultProcessor;
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

        [HttpGet("Interview/AddInterviewResult/{id}")]
        public IActionResult AddInterviewResult(int id)
        {
            InterviewResultViewModel interviewResultModel = new InterviewResultViewModel();
            var candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == id);

            if (candidate == null || candidate.InvitedToStudy == true)
            {
                return RedirectToAction(nameof(Interviews));
            }

            interviewResultModel.Candidate = candidate;

            if (_context.InterviewResults.Any(c => c.Candidate == candidate && _context.InterviewQuestionsAnswers.Any(c => c.Candidate == candidate)))
            {
                interviewResultModel.GeneralComment = _context.InterviewResults
                            .Where(c => c.Candidate == interviewResultModel.Candidate)
                            .Select(x => x.GeneralComment).FirstOrDefault();
                interviewResultModel.Value = _context.InterviewResults
                            .Where(c => c.Value == interviewResultModel.Value)
                            .Select(x => x.Value).FirstOrDefault();
                interviewResultModel.Comment = _context.InterviewQuestionsAnswers
                            .Where(c => c.Candidate == interviewResultModel.Candidate)
                            .Select(x => x.Comment).ToList();
                interviewResultModel.InterviewTaskQuestions = _context.InterviewQuestionsAnswers
                            .Where(c => c.Candidate == interviewResultModel.Candidate)
                            .Select(x => x.InterviewTask.InterviewTaskDescription).ToList();
            }
            else
            {
                List<InterviewTask> currentInterviewGeneralResultQuestions = _context.InterviewTasks
                            .OrderByDescending(d => d.Date)
                            .Take(9)
                            .ToList();

                for (int i = 0; i < 9; i++)
                {
                    interviewResultModel.Comment.Add("");
                    int InterviewTaskID = currentInterviewGeneralResultQuestions[i].InterviewTaskID;
                    string InterviewTaskDescription = _context.InterviewTasks
                            .Where(x => x.InterviewTaskID == InterviewTaskID)
                            .Select(x => x.InterviewTaskDescription)
                            .FirstOrDefault();
                    interviewResultModel.InterviewTaskQuestions.Add(InterviewTaskDescription);
                }
            }

            return View(interviewResultModel);
        }

        [HttpPost]
        public IActionResult AddInterviewResult(InterviewResultViewModel interviewResultViewModel, int id)
        {
            interviewResultViewModel.Candidate = _context.Candidates.FirstOrDefault(x => x.CandidateID == id);
            var CandidateHasInterviewResults = _context.InterviewResults
                        .Any(x => x.Candidate == interviewResultViewModel.Candidate);

            //if (CandidateHasInterviewResults)
            //{
            //    var candidateInterviewGeneralResults = _context.InterviewGeneralResults
            //                .Where(x => x.Candidate == interviewResultViewModel.Candidate)
            //                .ToList();
            //    var candidate
            //}

            List<InterviewTask> currentInterviewTask = _context.InterviewTasks
                        .OrderByDescending(x => x.Date)
                        .Take(9)
                        .ToList();

            var interviewResult = new InterviewResult()
            {
                Value = interviewResultViewModel.Value,
                GeneralComment = interviewResultViewModel.GeneralComment,
                Candidate = interviewResultViewModel.Candidate
            };

            _context.InterviewResults.Add(interviewResult);
            _context.SaveChanges();

            var CandidateHasInterviewRQuestionsAnswers = _context.InterviewQuestionsAnswers
                        .Any(x => x.Candidate == interviewResultViewModel.Candidate);

            for (int i = 0; i < interviewResultViewModel.Comment.Count; i++)
            {
                var interviewQuestionsAnswers = new InterviewQuestionsAnswers()
                {
                    InterviewTask = currentInterviewTask[i],
                    Comment = interviewResultViewModel.Comment[i],
                    Candidate = interviewResultViewModel.Candidate
                };

                _context.InterviewQuestionsAnswers.Add(interviewQuestionsAnswers);
                _context.SaveChanges();
            }




            var validationResultMessage = _candidateInterviewResultProcessor
                        .ValidateInterviewResultsToTestResultLimits(currentInterviewTask, interviewResultViewModel);

            return RedirectToAction(nameof(Interviews));
        }
    }
}