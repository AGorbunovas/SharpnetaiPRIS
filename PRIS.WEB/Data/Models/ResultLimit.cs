using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class ResultLimit
    {
        [Key]
        public int ResultLimitsId { get; set; }
        public string DateLimitSet { get; set; }
        public int? TaskId { get; set; }
        public IList<TestTask> TestTasks { get; set; }
    }
}
