using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Logic
{
    public class CandidateInterviewResultProcessor : ICandidateInterviewResultProcessor
    {
        public void SaveInitialCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, List<InterviewTask> currentInterviewTasks, ApplicationDbContext _context)
        {
            //for (int i = 0; i < interviewResultViewModel.Comment.Count; i++)
            //{
            //    var interviewGeneralResult = new InterviewGeneralResult
            //    {
            //        InterviewQuestionsAnswers = interviewResultViewModel.Comment[i],
            //        Candidate = interviewResultViewModel.Candidate,
            //        InterviewQuestionsAnswersID = currentInterviewTasks[i]
            //    };

            //    _context.TaskResult.Add(taskResult);
            //    _context.SaveChanges();
            //}
        }

        public void UpdateExistingCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, ApplicationDbContext _context, List<InterviewQuestionsAnswers> candidateInterviewCommentsInAnswers)
        {
            for (int i = 0; i < interviewResultViewModel.Comment.Count; i++)
            {
                _context.Attach(candidateInterviewCommentsInAnswers[i]);
                candidateInterviewCommentsInAnswers[i].Comment = interviewResultViewModel.Comment[i];
                _context.SaveChanges();
            }
        }

        public string ValidateInterviewResultsToTestResultLimits(List<InterviewTask> interviewTasks, InterviewResultViewModel interviewResultViewModel)
        {
            string message = null;

            if (interviewResultViewModel.GeneralComment == null)
            {
                message = $"Pagrindinis komentaras negali būti tuščias";
            }

            return message;
        }
    }
}
