using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.TaskGroupViewModel
{
    public class AddTaskGroupViewModel
    {
        [Display(Name = "Užduočių grupė")]
        [Required(ErrorMessage = "Įvedimo laukas negali būti tuščias")]
        [StringLength(50, ErrorMessage = "Užduočių grupės pavadinimas turi būti bent iš {2} simbolių, bet ne ilgesnis nei {1} simbolių", MinimumLength = 4)]
        public string TaskGroupName { get; set; }
        [Display(Name = "Užduočių arba klausimų skaičius")]        
        //[RegularExpression(@"^(?:[0-9]{1,2})$", ErrorMessage = "Pasirinkite reikšmę nuo 0 iki 20")]
        public int TaskGroupCount { get; set; }

        public IList<TaskGroup> TaskGroups { get; set; }   
        public IList<InterviewTask> InterviewTasks { get; set; }
    }
}
