using System.ComponentModel.DataAnnotations;

namespace PRIS.WEB.Models
{
    public class Module
    {
        public int ModuleID { get; set; }
        [Required]
        public string ModuleName { get; set; }
    }
}
