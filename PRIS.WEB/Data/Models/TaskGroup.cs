using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class TaskGroup
    {
        public int TaskGroupID { get; set; }
        [Required]
        public string TaskGroupName { get; set; }
        public int TaskGroupCount { get; set; }

        public virtual ICollection<InterviewTask> InterviewTasks { get; set; }

        public TaskGroup()
        {
            this.InterviewTasks = new List<InterviewTask>();
        }
    }
}
