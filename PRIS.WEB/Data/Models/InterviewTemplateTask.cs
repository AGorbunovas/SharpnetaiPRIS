using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class InterviewTemplateTask
    {
        public int InterviewTemplateID { get; set; }
        public InterviewTemplate InterviewTemplate { get; set; }

        public int InterviewTaskID { get; set; }
        public InterviewTask InterviewTask { get; set; }
    }
}
