using Microsoft.AspNetCore.Mvc.Rendering;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Views.Shared
{
    public static class ManageCollumnNavPages
    {
        public static string City => "City";
        public static string Module => "Module";
        public static string ResultLimitsView => "ResultLimitsView";        
        public static string List => "TestList";
        public static string Test => "TestCreate";
        public static string TaskGroup => "TaskGroup";
        public static string InterviewTaskList => "InterviewTaskList";
        public static string AcademicYear => "AcademicYear";
        public static string Interview => "Interview";
        public static string Contracts => "Contracts";
        public static string ContractsSigned => "ContractsSigned";
        public static string Candidate => "Candidate";
        public static string CandidateList => "CandidateList";


        public static string CityNavClass(ViewContext viewContext) => PageNavClass(viewContext, City);
        public static string ModuleNavClass(ViewContext viewContext) => PageNavClass(viewContext, Module);
        public static string ResultLimits_ViewNavClass(ViewContext viewContext) => PageNavClass(viewContext, ResultLimitsView);
        public static string TestListNavClass(ViewContext viewContext) => PageNavClass(viewContext, List);
        public static string TestCreateNavClass(ViewContext viewContext) => PageNavClass(viewContext, Test);
        public static string TaskGroupNavClass(ViewContext viewContext) => PageNavClass(viewContext, TaskGroup);
        public static string InterviewTaskNavClass(ViewContext viewContext) => PageNavClass(viewContext, InterviewTaskList);
        public static string AcademicYearNavClass(ViewContext viewContext) => PageNavClass(viewContext, AcademicYear);
        public static string InterviewNavClass(ViewContext viewContext) => PageNavClass(viewContext, Interview);
        public static string ContractNavClass(ViewContext viewContext) => PageNavClass(viewContext, Contracts);
        public static string ContractsSignedNavClass(ViewContext viewContext) => PageNavClass(viewContext, ContractsSigned);
        public static string CandidateNavClass(ViewContext viewContext) => PageNavClass(viewContext, Candidate);
        public static string CandidateListNavClass(ViewContext viewContext) => PageNavClass(viewContext, CandidateList);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
