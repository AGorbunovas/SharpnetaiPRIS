using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class ResultLimits
    {
        [Key]
        public int ResultLimitsId { get; set; }
        public string DateLimitSet { get; set; }
        public int Task1 { get; set; }
        public int Task2 { get; set; }
        public int Task3 { get; set; }
        public int Task4 { get; set; }
        public int Task5 { get; set; }
        public int Task6 { get; set; }
        public int Task7 { get; set; }
        public int Task8 { get; set; }
        public int Task9 { get; set; }
        public int Task10 { get; set; }
    }
}
