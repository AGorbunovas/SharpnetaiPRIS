using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data.Models
{
    public class TestTemplate
    {
        [Key]
        public int TemplateId { get; set; }
        public int TaskId { get; set; }
        public IList<TestTask> TestTasks { get; set; } 
    }
}
