using System;
using System.Collections.Generic;
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
        public DateTime ContractDate { get; set; }
        public ContractType ContractType { get; set; }
        public string SignedByFirstName { get; set; }
        public string SignedByLastName { get; set; } 
        public bool IsContractSigned { get; set; }

        public string SignedBy()
        {
            return SignedByFirstName + " " + SignedByLastName;
        }
    }
}
