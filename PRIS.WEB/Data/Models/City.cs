using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class City
    {
        public string CityName { get; set; }
        public int CityId { get; set; }

        public IList<City> Cities { get; set; }
    }
}
