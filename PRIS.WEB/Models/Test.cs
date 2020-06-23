using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRIS.WEB.Models
{
    public class Test
    {
        [DataType(DataType.Date)]
        [Display(Name = "Testo data")]
        [Required(ErrorMessage = "Įveskite datą")]
        public DateTime? DateOfTest { get; set; }

        [Display(Name = "Miestas")]
        [Required(ErrorMessage = "Įveskite miestą")]
        public String City { get; set; }
        public int TestId { get; set; }

        [NotMapped]
        public List<SelectListItem> Cities { get; set; }

    }
}
