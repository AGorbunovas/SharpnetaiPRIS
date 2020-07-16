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
        //public InterviewTask()
        //{
        //    InterviewTemplates = new HashSet<InterviewTemplate>();
        //}

        public int InterviewTaskID { get; set; }
        [Required]
        public string InterviewTaskDescription { get; set; }
        
        //[Required]
        public int TaskGroupID { get; set; }
        public TaskGroup TaskGroup { get; set; }

        //public virtual ICollection<InterviewTemplate> InterviewTemplates { get; set; }

    }
}