using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Logic
{
    public interface ICandidateInterviewResultProcessor
    {
        string ValidateInterviewResultsToTestResultLimits(List<InterviewTask> interviewTasks, InterviewResultViewModel interviewResultViewModel);
        void UpdateExistingCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, ApplicationDbContext _context, List<InterviewQuestionsAnswers> candidateInterviewCommentsInAnswers);
        void SaveInitialCandidateInterviewResults(InterviewResultViewModel interviewResultViewModel, List<InterviewTask> currentInterviewTasks, ApplicationDbContext _context);
    }
}
