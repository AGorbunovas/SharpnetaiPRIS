using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class TestTask
    {
        [Key]
        public int TaskId { get; set; }

        [Column(TypeName = "decimal(18,1)")]
        public double? TaskResult { get; set; }

        //[Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        [Column(TypeName = "decimal(18,1)")]
        public decimal? MaxResultLimit { get; set; }     
        public TaskGroup TaskGroups { get; set; }
    }
}
