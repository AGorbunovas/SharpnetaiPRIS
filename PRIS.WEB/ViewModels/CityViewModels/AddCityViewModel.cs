using PRIS.WEB.Models;
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
        [StringLength(10, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} ir ne ilgesnis nei {1} simbolių.", MinimumLength = 4)]
        [RegularExpression("[^0-9]+$", ErrorMessage = "Naudokite tik raides")]
        public string CityName { get; set; }
        public int CityId { get; set; }

        public IList<City> Cities { get; set; }
    }
}
