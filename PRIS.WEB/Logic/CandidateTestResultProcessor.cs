using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Logic
{
    public class CandidateTestResultProcessor : ICandidateTestResultProcessor
    {

        public string ValidateTestResultsToTestResultLimits(List<TaskResultLimit> testResultLimits, TaskResultViewModel model)
        {
            string message = null;

            for (int i = 0; i < testResultLimits.Count; i++)
            {
                if (model.Value[i] > testResultLimits[i].MaxValue)
                {
                    message = $"Testas numeriu: {i + 1} negali būti didesnis negu {testResultLimits[i].MaxValue}";
                }
            }
            return message;
        }

        public void UpdateExistingCandidateResults(TaskResultViewModel model, ApplicationDbContext _context, List<TaskResult>  candidateTaskResults)
        {
            for (int i = 0; i < model.Value.Count; i++)
            {
                _context.Attach(candidateTaskResults[i]);
                candidateTaskResults[i].Value = model.Value[i];
                _context.SaveChanges();
            }
        }

        public void SaveInitialCandidateResults(TaskResultViewModel model, List<TaskResultLimit> currentTestResultLimits, ApplicationDbContext _context)
        {
            for (int i = 0; i < model.Value.Count; i++)
            {
                var taskResult = new TaskResult
                {
                    Value = model.Value[i],
                    Candidate = model.Candidate,
                    TaskResultLimit = currentTestResultLimits[i]
                };

                _context.TaskResult.Add(taskResult);
                _context.SaveChanges();
            }
        }
    }
}
