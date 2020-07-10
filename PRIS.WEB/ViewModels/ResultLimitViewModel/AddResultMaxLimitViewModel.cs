using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class AddResultMaxLimitViewModel 
    {
        [Key]
        public int ResultLimitsId { get; set; }
        public string DateLimitSet { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ResultSumMax { get; set; }
        public IList<TestTask> TestTasks { get; set; }
    }
}
