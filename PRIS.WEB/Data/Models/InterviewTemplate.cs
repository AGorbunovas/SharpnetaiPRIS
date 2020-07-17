using PRIS.WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.Data.Models
{
    public class InterviewTemplate
    {
        [Key]
        public int InterviewTemplateID { get; set; }

        public int InterviewTaskID { get; set; }
        public InterviewTask InterviewTask { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}