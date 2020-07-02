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
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task1 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task2 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task3 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task4 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task5 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task6 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task7 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task8 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task9 { get; set; }

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        public decimal? Task10 { get; set; }

        [Required(ErrorMessage = "Pasirinkite bendrą testo balo reikšmę")]
        [RegularExpression("^(1[0-9]|20)$", ErrorMessage = "Pasirinkite reikšmę nuo 10 iki 20 tik sveikaisiais skaičiais.")] 
        public decimal? ResultSumMax { get; set; }
        public IList<ResultLimits> ResultLimits { get; set; } 
    }
}
