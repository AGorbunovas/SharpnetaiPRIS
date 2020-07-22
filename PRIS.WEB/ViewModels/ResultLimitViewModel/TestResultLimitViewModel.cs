using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.ResultLimitViewModel
{
    
    public class TestResultLimitViewModel
    {
        public List<int> TaskResultLimitId { get; set; } = new List<int>();
        public List<int> Position { get; set; } = new List<int>();

        [Required(ErrorMessage = "Pasirinkite reikšmę")]
        [RegularExpression(@"^(?:[0-4](?:\.5|\,5)+|[1-5]+)$", ErrorMessage = "Pasirinkite reikšmę nuo 0.5 iki 5, kuri būtų 0.5 kartotinis")]
        //[Column(TypeName = "decimal(18,1)")]
        public List<double> MaxValue { get; set; } = new List<double>();
        public DateTime Date { get; set; } 
        public double LimitSumMax { get; set; }

        [Display(Name = "Užduočių grupė")]
        public List<TaskGroup> TaskGroupList { get; set; } = new List<TaskGroup>(); 
        public List<SelectListItem> TaskGroups { get; set; }

        [Required(ErrorMessage = "Pasirinkite užduočių grupę")]
        public string[] TaskGroupName { get; set; } 
    } 
}
