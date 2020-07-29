using PRIS.WEB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.ViewModels
{
    public class InterviewResultViewModel
    {
        public List<string> Comment { get; set; } = new List<string>();
        [Required(ErrorMessage = "Pokalbio balo reikšmė negali būti didesnė negu 10!")]
        public double Value { get; set; }
        [Required(ErrorMessage = "Pokalbio komentaras yra būtinas!")]
        public string GeneralComment { get; set; }
        public Candidate Candidate { get; set; }
        public List<string> InterviewTaskQuestions { get; set; } = new List<string>();
    }
}
