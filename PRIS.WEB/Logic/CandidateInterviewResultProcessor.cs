using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.ViewModels;
using System.Collections.Generic;

namespace PRIS.WEB.Logic
{
    public class CandidateInterviewResultProcessor : ICandidateInterviewResultProcessor
    {
        public void SaveInitialCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, List<InterviewTask> currentInterviewTasks, ApplicationDbContext _context)
        {
            var interviewResult = new InterviewResult()
            {
                Value = interviewResultViewModel.Value,
                GeneralComment = interviewResultViewModel.GeneralComment,
                Candidate = interviewResultViewModel.Candidate
            };

            _context.InterviewResults.Add(interviewResult);
            _context.SaveChanges();

            for (int i = 0; i < interviewResultViewModel.Comment.Count; i++)
            {
                var interviewQuestionsAnswers = new InterviewQuestionsAnswers()
                {
                    InterviewTask = currentInterviewTasks[i],
                    Comment = interviewResultViewModel.Comment[i],
                    Candidate = interviewResultViewModel.Candidate
                };

                _context.InterviewQuestionsAnswers.Add(interviewQuestionsAnswers);
                _context.SaveChanges();
            }
        }

        //public void UpdateExistingCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, ApplicationDbContext _context, InterviewResult interviewResult, List<InterviewQuestionsAnswers> candidateInterviewCommentsInAnswers)
        public void UpdateExistingCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, ApplicationDbContext _context, InterviewResult interviewResult)
        {
            //for (int i = 0; i < interviewResultViewModel.Comment.Count; i++)
            //{
            _context.Attach(interviewResult);
            interviewResult.GeneralComment = interviewResultViewModel.GeneralComment;
            interviewResult.Value = interviewResultViewModel.Value;
            _context.SaveChanges();
            //}
        }

        public string ValidateInterviewResultsToTestResultLimits(InterviewResult interviewResult, InterviewResultViewModel interviewResultViewModel)
        {
            string message = null;

            if (interviewResultViewModel.GeneralComment == null)
            {
                message = $"Pagrindinis komentaras negali būti tuščias";
            }

            if (interviewResultViewModel.Value > 10)
            {
                message = $"Pokalbio balas negali būti didesnis negu 10";
            }

            return message;
        }
    }
}