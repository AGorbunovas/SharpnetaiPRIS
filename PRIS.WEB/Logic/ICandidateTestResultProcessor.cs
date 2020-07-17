using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.ViewModels;
using System.Collections.Generic;

namespace PRIS.WEB.Logic
{
    public interface ICandidateTestResultProcessor
    {
        string ValidateTestResultsToTestResultLimits(List<TaskResultLimit> testResultLimits, TaskResultViewModel model);
        void UpdateExistingCandidateResults(TaskResultViewModel model, ApplicationDbContext _context, List<TaskResult> candidateTaskResults);
        void SaveInitialCandidateResults(TaskResultViewModel model, List<TaskResultLimit> currentTestResultLimits, ApplicationDbContext _context);
    }
}