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
        public Test Test { get; set; }

        public int TemplateId { get; set; }
        public TestTemplate TestTemplate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double TestResultAvg { get; set; }

        public int CandidateID { get; set; }
        public Candidate Candidates { get; set; } 
    }
}
