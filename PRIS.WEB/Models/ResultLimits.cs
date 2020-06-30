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
        public float Task1 { get; set; }
        public float Task2 { get; set; }
        public float Task3 { get; set; }
        public float Task4 { get; set; }
        public float Task5 { get; set; }
        public float Task6 { get; set; }
        public float Task7 { get; set; }
        public float Task8 { get; set; }
        public float Task9 { get; set; }
        public float Task10 { get; set; }
    }
}
