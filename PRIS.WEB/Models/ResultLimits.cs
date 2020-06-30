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
        public decimal? Task1 { get; set; }
        public decimal? Task2 { get; set; }
        public decimal? Task3 { get; set; }
        public decimal? Task4 { get; set; }
        public decimal? Task5 { get; set; }
        public decimal? Task6 { get; set; }
        public decimal? Task7 { get; set; }
        public decimal? Task8 { get; set; }
        public decimal? Task9 { get; set; }
        public decimal? Task10 { get; set; }
        public decimal? ResultSumMax { get; set; }
    }
}
