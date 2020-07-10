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
        public static string ResultLimits_View => "ResultLimits_View";        
        public static string List => "TestList";
        public static string Test => "TestCreate";
        public static string TaskGroup => "TaskGroup";


        public static string CityNavClass(ViewContext viewContext) => PageNavClass(viewContext, City);
        public static string ModuleNavClass(ViewContext viewContext) => PageNavClass(viewContext, Module);
        public static string ResultLimits_ViewNavClass(ViewContext viewContext) => PageNavClass(viewContext, ResultLimits_View);
        public static string TestListNavClass(ViewContext viewContext) => PageNavClass(viewContext, List);
        public static string TestCreateNavClass(ViewContext viewContext) => PageNavClass(viewContext, Test);
        public static string TaskGroupNavClass(ViewContext viewContext) => PageNavClass(viewContext, TaskGroup);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
