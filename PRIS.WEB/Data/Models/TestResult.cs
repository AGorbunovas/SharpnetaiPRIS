using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class TestResult
    {
        [Key]
        //info apie sukurta test event'a
        public int TestResultId { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }

        //testo uzduociu info su vieta rezultatu ivestimis
        public int TemplateId { get; set; }
        public TestTemplate TestTemplate { get; set; }

        //kandidato info
        public int? CandidateID { get; set; }
        public Candidate Candidates { get; set; }
    }
}
