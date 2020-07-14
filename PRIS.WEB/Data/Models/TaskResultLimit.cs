using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class TaskResultLimit
    {
        public int TaskResultLimitId { get; set; }
        public int Position { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
