using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels
{
    public class TaskResultViewModel
    {
        public List<int> Value { get; set; } = new List<int>();
        public Candidate Candidate { get; set; }
    }
}
