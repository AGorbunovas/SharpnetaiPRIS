using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.ViewModels.TestViewModels
{
    public class AddTestViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Testo data")]
        public DateTime DateOfTest { get; set; }

        [Display(Name = "Miestas")]
        public City City { get; set; }

        public List<SelectListItem> Cities { get; set; }

        [Required(ErrorMessage = "Įveskite miestą")]
        public string CityName { get; set; }
        public int TestId { get; set; }

        public AcademicYear AcademicYear { get; set; }
        public List<SelectListItem> AcademicYears { get; set; }
        public int AcademicYearID { get; set; }

    }
}
