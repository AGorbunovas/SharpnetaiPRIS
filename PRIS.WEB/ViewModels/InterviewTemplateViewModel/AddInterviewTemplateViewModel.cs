//using Microsoft.AspNetCore.Mvc.Rendering;
//using PRIS.WEB.Data.Models;
//using PRIS.WEB.Models;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace PRIS.WEB.ViewModels.InterviewTemplateViewModel
//{
//    public class AddInterviewTemplateViewModel
//    {
//        [Key]
//        public int InterviewTemplateID { get; set; }

//        [Display(Name = "Klausimai")]
//        public int?[] SelectedInterviewTasks { get; set; }
     
//        public List<SelectListItem> InterviewTasks { get; set; }

//        public int? AcademicYearID { get; set; }


//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
//        public AcademicYear AcademicYear { get; set; }
//        public List<SelectListItem> AcademicYears { get; set; }
//    }
//}