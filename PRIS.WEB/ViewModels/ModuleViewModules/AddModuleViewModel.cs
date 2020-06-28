using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.ModuleViewModels
{
    public class AddModuleViewModel
    {
        public int ModuleID { get; set; }

        [Display(Name = "Mokymų programa")]
        [Required(ErrorMessage = "Įvedimo laukas negali būti tuščias")]
        [StringLength(50, ErrorMessage = "Įvedamų simbolių skaičius turi būti tarp {2} ir {1} simbolių", MinimumLength = 4)]
        public string ModuleName { get; set; }

        public IList<Module> Modules { get; set; }
    }
}
