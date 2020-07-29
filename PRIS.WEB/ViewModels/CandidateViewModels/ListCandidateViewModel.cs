using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PRIS.WEB.Models;
using PRIS.WEB.Data.Models;

namespace PRIS.WEB.ViewModels.CandidateViewModels
{
    public class ListCandidateViewModel
    {
        public int CandidateID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TestDate { get; set; }
        public string TestCity { get; set; }
        public int? Result { get; set; } 
        public int? ResultPrc { get; set; }
        public string FirstModule { get; set; }
        public double TestResult { get; set; }
        public double MaxResult { get; set; }
        public string GeneralInterviewComment { get; set; }
        public double InterviewResult { get; set; }
        public bool InvitedToInterview { get; set; }
        public double GeneralResult { get; set; }
        public bool InvitedToStudy { get; set; }
        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
