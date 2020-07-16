using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.ViewModels.InterviewTaskViewModel
{
    public class AddInterviewTaskViewModel
    {
        [Key]
        public int InterviewTaskID { get; set; }

        [Required]
        public string InterviewTaskDescription { get; set; }

        [Display(Name = "Užduočių grupė")]
        public TaskGroup TaskGroup { get; set; }

        public List<SelectListItem> TaskGroups { get; set; }

        [Required(ErrorMessage = "Įveskite užduočių grupę")]
        public string TaskGroupName { get; set; }
    }
}