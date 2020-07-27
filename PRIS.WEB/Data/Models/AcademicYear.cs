using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class AcademicYear
    {
        public int AcademicYearID { get; set; }

        [DataType(DataType.Date)]
        public DateTime AcademicYearStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime AcademicYearEnd { get; set; }
    }
}
