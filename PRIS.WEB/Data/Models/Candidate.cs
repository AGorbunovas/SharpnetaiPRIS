using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class Candidate
    {
        public int CandidateID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Comment { get; set; }
        public ICollection<CandidateModule> CandidateModules { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }

        public bool InvitedToInterview { get; set; }
        public bool InvitedToStudy { get; set; }

        //public int ContractId { get; set; }
        //public Contract Contract { get; set; }
    }
}
