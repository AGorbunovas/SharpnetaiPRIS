using Newtonsoft.Json.Serialization;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels
{
    public class AddResultLimitsViewModel
    {
        public int ResultLimitsId { get; set; }
        public string DateLimitSet { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task1 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task2 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task3 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task4 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task5 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task6 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task7 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task8 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task9 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(1, 5, ErrorMessage = "Pasirinkite reikšmę nuo 1 iki 5.")]
        public int Task10 { get; set; }
        public IList<ResultLimits> ResultLimits { get; set; } 
    }
}
