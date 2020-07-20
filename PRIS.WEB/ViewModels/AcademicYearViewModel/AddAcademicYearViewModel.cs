using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.ViewModels.AcademicYearViewModel
{
    public class AddAcademicYearViewModel
    {
        [Key]
        public int AcademicYearID { get; set; }

        [Required(ErrorMessage = "Įvedimo laukas negali būti tuščias")]
        [DataType(DataType.Date)]
        [Display(Name = "Mokslo metų pradžia")]
        public DateTime AcademicYearStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Mokslo metų pabaiga")]
        public DateTime AcademicYearEnd { get; set; }

        private string _AcademicYearPeriod;

        [Display(Name = "Mokslo metų laikotarpis")]
        public string AcademicYearPeriod
        {
            
            get
            {
                _AcademicYearPeriod = AcademicYearStart.Date.ToShortDateString() + " - " + AcademicYearEnd.Date.ToShortDateString();
                return _AcademicYearPeriod;
            }
            set
            {
                _AcademicYearPeriod = value;
            }
        }

        public IList<AcademicYear> AcademicYear { get; set; }

        //public ICollection<Test> Tests { get; set; }
    }
}
