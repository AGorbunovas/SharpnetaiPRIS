using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.InterviewTaskViewModel
{
    public class AddInterviewTaskViewModel
    {
        public int InterviewTaskID { get; set; }

        [Required]
        public string InterviewTaskName { get; set; }
        [Display(Name = "Užduočių grupė")]
        public TaskGroup TaskGroup { get; set; }

        public List<SelectListItem> TaskGroups { get; set; }

        [Required(ErrorMessage = "Įveskite užduočių grupę")]
        public string TaskGroupName { get; set; }

    }
}
