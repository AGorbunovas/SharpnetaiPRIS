using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public enum ContractType
    {
        VF,
        VNF
    }
    public class Contract
    {
        public int ContractId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ContractDate { get; set; }
        public ContractType ContractType { get; set; }
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }

    }
}
