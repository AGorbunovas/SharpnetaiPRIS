using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PRIS.WEB.Models;

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
        public bool IsInterview { get; set; }
        public string FirstModule { get; set; }
        public double TestResult { get; set; }
        //TODO
        public double MaxResult { get; set; }
    }
}
