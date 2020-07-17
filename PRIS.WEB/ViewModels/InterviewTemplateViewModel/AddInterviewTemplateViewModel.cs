using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.ViewModels.InterviewTemplateViewModel
{
    public class AddInterviewTemplateViewModel
    {
        [Key]
        public int InterviewTemplateID { get; set; }

        public string InterviewTaskDescription { get; set; }

        [Required(ErrorMessage = "Įveskite užduočių grupę")]
        [Display(Name = "Klausimas")]
        public InterviewTask InterviewTask { get; set; }

        public List<SelectListItem> InterviewTasks { get; set; }

        public string TaskGroupName { get; set; }
        public TaskGroup TaskGroup { get; set; }
    }
}