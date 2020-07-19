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
        public int AcademicYearID { get; set; }

        [Required(ErrorMessage = "Įvedimo laukas negali būti tuščias")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Mokslo metų pradžia")]
        public DateTime AcademicYearStart { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Mokslo metų pabaiga")]
        public DateTime AcademicYearEnd { get; set; }

        private string _AcademicYearPeriod;

        [Display(Name = "Mokslo metų laikotarpis")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string AcademicYearPeriod
        {
            get
            {
                _AcademicYearPeriod = AcademicYearStart + " - " + AcademicYearEnd;
                return _AcademicYearPeriod;
            }
            set
            {
                _AcademicYearPeriod = value;
            }
        }

        public ICollection<Test> Tests { get; set; }
    }
}
