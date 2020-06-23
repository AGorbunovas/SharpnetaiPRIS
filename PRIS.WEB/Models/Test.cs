using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Models
{
    public class Test
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Testo data")]
        public DateTime DateOfTest { get; set; }
        [Required]
        public String City { get; set; }
    }
}
