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
    public class ResultMaxLimitViewModel
    {
        //public int ResultLimitsId { get; set; }
        //public ResultLimit ResultLimit { get; set; }
        public int TemplateId { get; set; }
        public TestTemplate TestTemplate { get; set; }
        //public TestTask TestTask { get; set; }
        //public IList<TestTask> TestTasks { get; set; }
        public TaskGroup TaskGroup { get; set; }
        public IList<TaskGroup> TaskGroups { get; set; }
        //public string DateLimitSet { get; set; }
    }
}
