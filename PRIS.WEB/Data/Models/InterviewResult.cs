using PRIS.WEB.Models;

namespace PRIS.WEB.Data.Models
{
    public class InterviewResult
    {
        public int InterviewResultID { get; set; }
        public string GeneralComment { get; set; }
        public double Value { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
