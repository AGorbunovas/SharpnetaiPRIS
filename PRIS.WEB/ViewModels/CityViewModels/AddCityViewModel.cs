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
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Miesto pavadinimas turi būti bent iš 4 simbolių, bet ne ilgesnis nei 10 simbolių")]
        [DataType(DataType.Text)]
        public string CityName { get; set; }
        public int CityId { get; set; }

        public IList<City> Cities { get; set; }
    }
}
