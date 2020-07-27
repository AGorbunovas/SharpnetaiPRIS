using PRIS.WEB.Models;
using System.Collections.Generic;

namespace PRIS.WEB.ViewModels
{
    public class InterviewResultViewModel
    {
        public List<string> Comment { get; set; } = new List<string>();
        public double Value { get; set; }
        public string GeneralComment { get; set; }
        public Candidate Candidate { get; set; }
        public List<string> InterviewTaskQuestions { get; set; } = new List<string>();
    }
}
