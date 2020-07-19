using PRIS.WEB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.Data.Models
{
    public class InterviewTemplate
    {
        [Key]
        public int InterviewTemplateID { get; set; }

        //public int InterviewTaskID { get; set; }
        //public InterviewTask InterviewTask { get; set; }

        public List<InterviewTask> InterviewTasks { get; set; }

        //public int TestId { get; set; }
        //public Test Test { get; set; }

        public List<Test> Tests { get; set; }

        public List<TaskGroup> TaskGroups { get; set; }

        public InterviewTemplate()
        {
            TaskGroups = new List<TaskGroup>();
            InterviewTasks = new List<InterviewTask>();
            Tests = new List<Test>();
        }
    }
}