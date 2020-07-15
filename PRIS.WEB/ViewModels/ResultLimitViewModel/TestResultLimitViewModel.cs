using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.ResultLimitViewModel
{
    public class TestResultLimitViewModel
    {
        public List<int> Position { get; set; } = new List<int>();  
        public List<int> Value { get; set; } = new List<int>();
        public string Date { get; set; } 
        public int LimitSumMax { get; set; }
    }
}
