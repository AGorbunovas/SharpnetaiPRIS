using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PRIS.WEB.Data;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using PRIS.WEB.ViewModels;
using PRIS.WEB.ViewModels.InterviewTaskViewModel;
using PRIS.WEB.ViewModels.ModuleViewModels;
using PRIS.WEB.ViewModels.TaskGroupViewModel;
using PRIS.WEB.ViewModels.ResultLimitViewModel;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace PRIS.WEB.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ApplicationDbContext _context;

        public SettingsController(ILogger<SettingsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Settings()
        {
            return RedirectToAction("City");
        }

        #region City/Create/Delete

        public IActionResult City()
        {
            if (TempData["TestIsAddedToTheCityErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["TestIsAddedToTheCityErrorMessage"].ToString());
            }
            return View(_context.Cities.ToList());
        }

        [HttpGet]
        public IActionResult CityModalPartial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CityModalPartial(AddCityViewModel city)
        {
            var check = _context.Cities.Any(x => x.CityName == city.CityName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Toks miestas jau yra sukurtas");
            }

            if (ModelState.IsValid)
            {
                var newRecord = new City() { CityName = city.CityName };
                if (newRecord != null)
                {
                    _context.Cities.Add(newRecord);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return View();
        }

        public IActionResult CityDelete(int id)
        {
            var testConnected = _context.Test.Any(x => x.City.CityId == id);

            if (testConnected)
            {
                TempData["TestIsAddedToTheCityErrorMessage"] = "Miesto trinti negalima - jam jau yra priskirtas testas.";
                return RedirectToAction("City");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Cities.SingleOrDefault(x => x.CityId == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("City");
            }
            return RedirectToAction("City");
        }

        #endregion City/Create/Delete

        #region Module

        public IActionResult Module()
        {
            if (TempData["IsTestUsedInCandidateModuleTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInCandidateModuleTableErrorMessage"].ToString());
            }
            return View("Module", _context.Modules.OrderBy(m => m.ModuleName).ToList());
        }

        #endregion Module

        #region Module/Create

        public IActionResult ModuleCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModuleCreate(AddModuleViewModel module)
        {
            var check = _context.Modules.Any(m => m.ModuleName == module.ModuleName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Tokia mokymų programa jau yra sukurta");
                return View();
            }

            if (ModelState.IsValid)
            {
                var newModule = new Module() { ModuleName = module.ModuleName };
                if (newModule != null)
                {
                    _context.Modules.Add(newModule);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return View();
        }

        #endregion Module/Create

        #region Module/Delete

        public IActionResult ModuleDelete(int id)
        {
            var testConnected = _context.CandidateModules.Any(x => x.Module.ModuleID == id);

            if (testConnected)
            {
                TempData["IsTestUsedInCandidateModuleTableErrorMessage"] = "Negalima trinti mokymo programos, nes ji yra priskirta prie kandidato!";
                return RedirectToAction("Module");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.Modules.SingleOrDefault(x => x.ModuleID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("Module");
            }
            return RedirectToAction("Module");
        }

        #endregion Module/Delete

        #region ResultLimits/Create

        public IActionResult ResultLimits_View()
        {
            var taskLimits = _context.TaskResultLimits.ToList();

            List<TestResultLimitViewModel> model = new List<TestResultLimitViewModel>();

            return View(model);
        }

        [HttpGet]
        public IActionResult ResultLimits_Create()
        {
            TestResultLimitViewModel model = new TestResultLimitViewModel();

            //model.Position = new List<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    model.Position.Add(i+1);
            //}

            for (int i = 0; i < 10; i++)
            {
                model.maxValue.Add(1);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ResultLimits_Create(TestResultLimitViewModel model)
        {
            //TODO rezultatu limitai susije su testo sablonu

            string timeStamp = GetTimestamp(DateTime.Now);

            for (int i = 0; i < model.maxValue.Count; i++)
            {
                var limitTask = new TaskResultLimit();
                limitTask.Date = timeStamp;
                limitTask.Position = i + 1;
                limitTask.maxValue = model.maxValue[i];

                _context.TaskResultLimits.Add(limitTask);
                _context.SaveChanges();
            }

            //skaiciuoju visu uzduociu reziu suma
            for (int i = 0; i < model.maxValue.Count; i++)
            {
                model.LimitSumMax += model.maxValue[i];
            }

            return View(model);
        }

        private string GetTimestamp(DateTime now)
        {
            return now.Date.ToString();
        }

        #endregion ResultLimits/Create

        #region TaskGroup

        //public IActionResult TaskGroup()
        //{
        //    var taskGroupModel = _context.TaskGroups
        //        .ProjectTo<AddTaskGroupViewModel>(_mapper.ConfigurationProvider).ToList();

        //    return View(taskGroupModel);
        //}

        public IActionResult TaskGroup()
        {
            if (TempData["IsTestUsedInTaskGroupModuleTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsTestUsedInTaskGroupModuleTableErrorMessage"].ToString());
            }
            return View("TaskGroup", _context.TaskGroups.OrderBy(m => m.TaskGroupName).ToList());
        }

        

        #region TaskGroup/Create

        public IActionResult TaskGroupCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskGroupCreate(AddTaskGroupViewModel addTaskGroup)
        {
            var check = _context.TaskGroups.Any(t => t.TaskGroupName == addTaskGroup.TaskGroupName);

            if (check)
            {
                ModelState.AddModelError(string.Empty, "Tokia užduočių grupė jau yra sukurta");
                return View();
            }

            if (ModelState.IsValid)
            {
                //var newTaskGroup = new TaskGroup() { TaskGroupName = addTaskGroup.TaskGroupName, TaskGroupCount = addTaskGroup.TaskGroupCount };
                var newTaskGroup = new TaskGroup() { TaskGroupName = addTaskGroup.TaskGroupName };
                if (newTaskGroup != null)
                {
                    _context.TaskGroups.Add(newTaskGroup);
                    _context.SaveChanges();
                }
                return RedirectToAction("TaskGroup");
            }
            return View();
        }

        #endregion

        #region TaskGroup/Delete

        public IActionResult TaskGroupDelete(int id)
        {
            var testConnected = _context.InterviewTasks.Any(x => x.TaskGroup.TaskGroupID == id);

            if (testConnected)
            {
                TempData["IsTestUsedInInterviewTaskModuleTableErrorMessage"] = "Negalima trinti užduočių grupės, nes ji yra susieta su pokalbio užduotimis!";
                return RedirectToAction("TaskGroup");
            }
            else if (ModelState.IsValid)
            {
                var data = _context.TaskGroups.SingleOrDefault(t => t.TaskGroupID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("TaskGroup");
            }
            return RedirectToAction("TaskGroup");
        }

        #endregion --- TaskGroup/Delete ---

        #endregion TaskGroup

        #region InterviewTask

        public IActionResult InterviewTask()
        {
            AddInterviewTaskViewModel viewModel = GetViewModelWithTaskGroupList();
            return View("InterviewTask", viewModel);
        }

        #region InterviewTask/List

        public IActionResult InterviewTaskList()
        {
            IEnumerable<AddInterviewTaskViewModel> data = _context.InterviewTasks.Select(i =>
            new AddInterviewTaskViewModel()
            {
                InterviewTaskDescription = i.InterviewTaskDescription,
                TaskGroup = i.TaskGroup,
                InterviewTaskID = i.InterviewTaskID
            }).ToList();

            if (TempData["IsInterviewTaskUsedInCandidateTableErrorMessage"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["IsInterviewTaskUsedInCandidateTableErrorMessage"].ToString());
            }

            return View(data);
        }

        #endregion InterviewTask/List

        #region InterviewTask/Create

        //public IActionResult InterviewTaskCreate()
        //{
        //    ViewData["TaskGroupName"] = new SelectList(_context.TaskGroups, "TaskGroupName");
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InterviewTaskCreate([Bind("InterviewTaskID, InterviewTaskName, TaskGroupName")] AddInterviewTaskViewModel addInterviewTaskViewModel)
        {
            var isNotUnique = _context.InterviewTasks.Any(t => t.TaskGroup.TaskGroupName == addInterviewTaskViewModel.TaskGroupName);

            if (isNotUnique)
            {
                ModelState.AddModelError(string.Empty, "Tokia užduočių grupė jau yra sukurta");
            }

            if (ModelState.IsValid)
            {
                TaskGroup taskGroup = _context.TaskGroups.FirstOrDefault(t => t.TaskGroupName == addInterviewTaskViewModel.TaskGroupName);
                if (taskGroup != null)
                {
                    InterviewTask newRecord = new InterviewTask() { TaskGroup = taskGroup, InterviewTaskDescription = addInterviewTaskViewModel.InterviewTaskDescription };
                    _context.InterviewTasks.Add(newRecord);
                    _context.SaveChanges();
                }
                return RedirectToAction("InterviewTaskList");
            }

            AddInterviewTaskViewModel viewModel = GetViewModelWithTaskGroupList();
            return View(viewModel);
        }

        #endregion InterviewTask/Create

        #region InterviewTask/Delete

        public IActionResult InterviewTaskDelete(int id)
        {
            //TODO patikrinimas jei užduotis jau yra priskirta pokalbio šablonui
            //var testConnected = _context.Candidates.Any(x => x.TaskGroup.TaskGroupID == id);

            //if (testConnected)
            //{
            //    TempData["IsTestUsedInInterviewTaskModuleTableErrorMessage"] = "Negalima trinti užduočių grupės, nes ji yra susieta su pokalbio užduotimis!";
            //    return RedirectToAction("TaskGroup");
            //}
            //else
            if (ModelState.IsValid)
            {
                var data = _context.TaskGroups.SingleOrDefault(t => t.TaskGroupID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("InterviewTask");
            }
            return RedirectToAction("InterviewTask");
        }

        #endregion InterviewTask/Delete
        
        private AddInterviewTaskViewModel GetViewModelWithTaskGroupList()
        {
            var taskGroupsData = _context.TaskGroups.Select(x => new SelectListItem()
            {
                Value = x.TaskGroupName,
                Text = x.TaskGroupName
            }).ToList();

            var viewModel = new AddInterviewTaskViewModel()
            {
                TaskGroups = taskGroupsData
            };

            return viewModel;
        }

        //=========================================================

        //private bool InterviewTasksExists(int id)
        //{
        //    return _context.InterviewTasks.Any(e => e.InterviewTaskID == id);
        //}

        #endregion InterviewTask
    }
}