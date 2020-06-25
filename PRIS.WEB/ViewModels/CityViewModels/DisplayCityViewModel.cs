using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels
{
    public class DisplayCityViewModel
    {
        public string CityName { get; set; }
        public IList<City> Cities { get; set; }
    }
}
