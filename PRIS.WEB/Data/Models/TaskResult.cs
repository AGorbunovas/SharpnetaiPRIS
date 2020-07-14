using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class TaskResult
    {
        public int TaskResultId { get; set; }
        public int Value { get; set; }

        public TaskResultLimit TaskResultLimit { get; set; }
        public int TaskResultLimitId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
