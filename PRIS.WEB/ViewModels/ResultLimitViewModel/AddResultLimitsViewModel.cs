using Newtonsoft.Json.Serialization;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels
{
    public class AddResultLimitsViewModel
    {
        public int ResultLimitsId { get; set; }
        public string DateLimitSet { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        //[RegularExpression("^(?: 5(?:\.5) ?|[0 - 5](?:\.[5]) ?| 0 ?\.[0])$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.)]
        [Column(TypeName = "decimal(18, 5)")]
        public float Task1 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task2 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task3 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task4 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task5 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task6 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task7 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task8 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task9 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [Range(0.5, 5, ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5.")]
        public float Task10 { get; set; }
        public IList<ResultLimits> ResultLimits { get; set; } 
    }
}
