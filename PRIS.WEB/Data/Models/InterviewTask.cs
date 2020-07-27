using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class InterviewTask
    {
        public int InterviewTaskID { get; set; }
        [Required]
        public string InterviewTaskDescription { get; set; }

        public DateTime Date { get; set; }
        public int Position { get; set; }

    }
}