using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.ViewModels.InterviewTaskViewModel
{
    public class AddInterviewTaskViewModel
    {
        [Key]
        public List<int> InterviewTaskID { get; set; } = new List<int>();
        public List<int> Position { get; set; } = new List<int>();

        [Required(ErrorMessage = "Įveskite pokalbio klausimą")]
        public List<string> InterviewTaskDescription { get; set; } = new List<string>();

        //public string[] InterviewTaskDescription { get; set; }

        public DateTime Date { get; set; }
    }
}