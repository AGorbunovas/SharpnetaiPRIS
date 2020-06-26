using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PRIS.WEB.Models;

namespace PRIS.WEB.ViewModels.TestViewModels
{
    public class AddTestViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Testo data")]
        [Required(ErrorMessage = "Įveskite datą")]
        public DateTime? DateOfTest { get; set; }

        [Display(Name = "Miestas")]
        public City City { get; set; }
        
        public List<SelectListItem> Cities { get; set; }

        [Required(ErrorMessage = "Įveskite miestą")]
        public string CityName { get; set; }
        public int TestId { get; set; }
        public List<Test> ListOfTests { get; set; }
    }
}
