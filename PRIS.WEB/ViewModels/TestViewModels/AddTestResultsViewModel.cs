using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class AddTestResultsViewModel
    {
        public int TestId { get; set; }
        public int TaskId { get; set; }
        public IList<TestTask> TestTasks { get; set; }
        public double? TaskResult { get; set; }
        public decimal? MaxResultLimit { get; set; }

        public int CandidateID { get; set; }
        public IList<Candidate> Candidates { get; set; } 
    }
}
