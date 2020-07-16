using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.ResultLimitViewModel
{
    
    public class TestResultLimitViewModel
    {
        public List<int> Position { get; set; } = new List<int>();

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        [Column(TypeName = "decimal(18,1)")]
        public List<int> maxValue { get; set; } = new List<int>();
        public string Date { get; set; } 
        public int LimitSumMax { get; set; }
    }
}
