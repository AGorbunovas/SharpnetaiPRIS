using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class ResultsTA
    {
        public Candidate Candidate { get; set; }
        public int CandidateID { get; set; }

        public int Result { get; set; }

        public ResultLimitTA ResultLimitTA { get; set; }
        public int ResultLimitTAId { get; set; }

        public int ResultsTAId { get; set; }
    }
}
