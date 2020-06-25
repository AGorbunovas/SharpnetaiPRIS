using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels
{
    public class AddCityViewModel
    {
        [Display(Name = "Miesto pavadinimas")]
        [Required(ErrorMessage = "Įveskite miesto pavadinimą")]
        public string CityName { get; set; }
        public int CityId { get; set; }
    }
}
