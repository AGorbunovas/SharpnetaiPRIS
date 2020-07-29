using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.ContractViewModule
{
    public class CandidateContractViewModel
    {
        public int CandidateID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FirstModule { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TestDate { get; set; }
        public string TestCity { get; set; }
        public double TestResult { get; set; }
        public double InterviewResult { get; set; }
        public double GeneralResult { get; set; }
        public string GeneralInterviewComment { get; set; }
        public string AcademicYear { get; set; }
        public bool InvitedToStudy { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ContractDate { get; set; }
        public ContractType ContractType { get; set; }
        public bool IsContractSigned { get; set; }
        public int ContractId { get; set; }
    }
}
