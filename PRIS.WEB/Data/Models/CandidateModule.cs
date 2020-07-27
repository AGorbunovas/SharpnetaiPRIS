namespace PRIS.WEB.Models
{
    public class CandidateModule
    {
        public int ModuleID { get; set; }
        public Module Module { get; set; }

        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public int OrderNr { get; set; }
    }
}