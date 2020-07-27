using PRIS.WEB.Models;

namespace PRIS.WEB.Data.Models
{
    public class InterviewQuestionsAnswers
    {
        public int InterviewQuestionsAnswersID { get; set; }
        public string Comment { get; set; }

        public int InterviewTaskID { get; set; }
        public InterviewTask InterviewTask { get; set; }

        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
    }
}
