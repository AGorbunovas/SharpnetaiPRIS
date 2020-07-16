using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{

    public class TaskResultLimit
    {
        public int TaskResultLimitId { get; set; }
        public int Position { get; set; }
        public DateTime Date { get; set; }
        public double? MaxValue { get; set; } 
    }
}
