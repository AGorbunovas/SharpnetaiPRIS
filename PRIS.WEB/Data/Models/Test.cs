using PRIS.WEB.Data.Models;
using System;

namespace PRIS.WEB.Models
{
    public class Test
    {
        public DateTime DateOfTest { get; set; }
        public int TestId { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int AcademicYearID { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
