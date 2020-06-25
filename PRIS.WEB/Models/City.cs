﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class City
    {
        [Required(ErrorMessage ="Įveskite miesto pavadinimą")]
        public string CityName { get; set; }
        public int CityId { get; set; }
    }
}
