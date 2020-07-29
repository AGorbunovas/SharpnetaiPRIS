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
using PRIS.WEB.ViewModels.AcademicYearViewModel;
using System.Diagnostics.CodeAnalysis;
using PRIS.WEB.ViewModels.InterviewTemplateViewModel;

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

        #region ResultLimits/Create/Delete

        public IActionResult ResultLimitsView()
        {
            var taskLimits = _context.TaskResultLimits.OrderByDescending(x => x.Date).ToList();
            var countOfLimitTemplateForOneTest = taskLimits.Count() / 10;

            List<TestResultLimitViewModel> model = new List<TestResultLimitViewModel>();

            for (int i = 0; i < countOfLimitTemplateForOneTest; i++)
            {
                var limitTemplate = taskLimits.GetRange(i * 10, 10).ToList();
                var dateOfLimits = limitTemplate.Select(x => x.Date).First();

                model.Add(new TestResultLimitViewModel()
                {
                    MaxValue = new List<double>(),
                    TaskGroupList = new List<TaskGroup>(),
                    TaskResultLimitId = new List<int>(),
                    Date = dateOfLimits,
                    LimitSumMax = limitTemplate.Sum(y => y.MaxValue)
                });

                foreach (var item in limitTemplate)
                {
                    model[i].MaxValue.Add(item.MaxValue);
                    model[i].TaskGroupList.Add(item.TaskGroup);
                    model[i].TaskResultLimitId.Add(item.TaskResultLimitId);
                };
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResultLimitsCreate()
        {
            TestResultLimitViewModel model = GetLimitViewModelWithTaskGroupList();

            return View(model);
        }

        [HttpPost]
        public IActionResult ResultLimitsCreate(TestResultLimitViewModel resultLimitModel)
        {
            bool isFirstResultLimitForAcademicYear = _context.TaskResultLimits.Any(x => x.AcademicYearID == resultLimitModel.AcademicYearID);
            if(isFirstResultLimitForAcademicYear)
            {
                var maxValueSum = _context.TaskResultLimits.Where(x => x.AcademicYearID == resultLimitModel.AcademicYearID).Take(10).Sum(x => x.MaxValue);
                var resultMaxValueSum = resultLimitModel.MaxValue.Sum();
                if (maxValueSum != resultMaxValueSum)
                {
                    ModelState.AddModelError("", "Maksimalių balų limitas nesutampa su praeitu limitu");
                    TestResultLimitViewModel model = GetLimitViewModelWithTaskGroupList();
                    model.MaxValue = resultLimitModel.MaxValue;
                    return View(model);
                }
            }

            DateTime timeStamp = DateTime.Now;

            for (int i = 0; i < resultLimitModel.MaxValue.Count; i++)
            {
                TaskGroup taskGroup = _context.TaskGroups.FirstOrDefault(t => t.TaskGroupName == resultLimitModel.TaskGroupName[i]);

                var limitTask = new TaskResultLimit();

                limitTask.Date = timeStamp;
                limitTask.Position = i + 1;
                limitTask.MaxValue = resultLimitModel.MaxValue[i];
                limitTask.TaskGroup = taskGroup;
                limitTask.AcademicYearID = resultLimitModel.AcademicYearID;

                _context.TaskResultLimits.Add(limitTask);
                _context.SaveChanges();
            }
            return RedirectToAction("ResultLimitsView");
        }

        private TestResultLimitViewModel GetLimitViewModelWithTaskGroupList()
        {
            var testTaskGroupData = _context.TaskGroups.Select(x => new SelectListItem()
            {
                Value = x.TaskGroupName,
                Text = x.TaskGroupName.ToString()
            }).ToList();

            var viewModel = new TestResultLimitViewModel()
            {
                TaskGroups = testTaskGroupData
            };

            for (int i = 0; i < 10; i++)
            {
                viewModel.MaxValue.Add(0.5);
            }

            var academicYears = _context.AcademicYears.OrderByDescending(x => x.AcademicYearID).Select(i => new SelectListItem()
            {
                Value = i.AcademicYearID.ToString(),
                Text = i.AcademicYearStart.ToString("yyyy-MM-dd") + "  ||  " + i.AcademicYearEnd.ToString("yyyy-MM-dd")
            }).ToList();

            viewModel.AcademicYears = academicYears;

            return viewModel;
        }

        #endregion ResultLimits/Create/Delete

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
            var testConnected = _context.TaskResultLimits.Any(x => x.TaskGroup.TaskGroupID == id);

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

        #region InterviewTask/List

        public IActionResult InterviewTaskList()
        {
            var interviewTaskLimits = _context.InterviewTasks.OrderByDescending(i => i.Date).ToList();
            var countOfLimitTemplateForOneTest = interviewTaskLimits.Count() / 9;

            List<AddInterviewTaskViewModel> viewModel = new List<AddInterviewTaskViewModel>();

            for (int i = 0; i < countOfLimitTemplateForOneTest; i++)
            {
                var limitTemplate = interviewTaskLimits.GetRange(i * 9, 9).ToList();
                var dateOfLimits = limitTemplate.Select(i => i.Date).FirstOrDefault();

                viewModel.Add(new AddInterviewTaskViewModel()
                {
                    InterviewTaskID = new List<int>(),
                    InterviewTaskDescription = new List<string>(),
                    Date = dateOfLimits
                });

                foreach (var item in limitTemplate)
                {
                    viewModel[i].InterviewTaskID.Add(item.InterviewTaskID);
                    viewModel[i].InterviewTaskDescription.Add(item.InterviewTaskDescription);
                };
            }

            return View(viewModel);
        }

        #endregion InterviewTask/List

        #region InterviewTask/Create

        [HttpGet]
        public IActionResult InterviewTaskCreate()
        {
            AddInterviewTaskViewModel viewModel = GetQuestionsViewModelList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InterviewTaskCreate(AddInterviewTaskViewModel addInterviewTaskViewModel)
        {
            DateTime timeStamp = DateTime.Now;

            for (int i = 0; i < addInterviewTaskViewModel.InterviewTaskDescription.Count; i++)
            {
                var limitTask = new InterviewTask();

                limitTask.Date = timeStamp;
                limitTask.Position = i + 1;
                limitTask.InterviewTaskDescription = addInterviewTaskViewModel.InterviewTaskDescription[i];

                _context.InterviewTasks.Add(limitTask);
                _context.SaveChanges();
            }

            return RedirectToAction("InterviewTaskList");
        }

        #endregion InterviewTask/Create

        //#region InterviewTask/Edit

        //public IActionResult InterviewTaskDelete(int id)
        //{
        //    //TODO patikrinimas jei užduotis jau yra priskirta pokalbio šablonui
        //    //var testConnected = _context.Candidates.Any(x => x.TaskGroup.TaskGroupID == id);

        //    //if (testConnected)
        //    //{
        //    //    TempData["IsTestUsedInInterviewTaskModuleTableErrorMessage"] = "Negalima trinti užduočių grupės, nes ji yra susieta su pokalbio užduotimis!";
        //    //    return RedirectToAction("TaskGroup");
        //    //}
        //    //else
        //    if (ModelState.IsValid)
        //    {
        //        var data = _context.InterviewTasks.SingleOrDefault(i => i.InterviewTaskID == id);
        //        if (data != null)
        //        {
        //            _context.Remove(data);
        //            _context.SaveChanges();
        //        }
        //        return RedirectToAction("InterviewTaskList");
        //    }
        //    return RedirectToAction("InterviewTaskList");
        //}

        //#endregion InterviewTask/Edit 

        #region InterviewTask/GetQuestions

        private AddInterviewTaskViewModel GetQuestionsViewModelList()
        {
            var viewModel = new AddInterviewTaskViewModel();

            for (int i = 0; i < 9; i++)
            {
                viewModel.InterviewTaskDescription.Add("");
            }
            return viewModel;
        }

        #endregion InterviewTask/GetQuestions

        #endregion InterviewTask

        #region AcademicYear

        #region AcademicYear/List

        public IActionResult AcademicYear()
        {
            IEnumerable<AddAcademicYearViewModel> data = _context.AcademicYears.Select(i =>
            new AddAcademicYearViewModel()
            {
                AcademicYearID = i.AcademicYearID,
                AcademicYearStart = i.AcademicYearStart,
                AcademicYearEnd = i.AcademicYearEnd
            }).ToList();

            //if (TempData["IsTestUsedInAcademicYearTableErrorMessage"] != null)
            //{
            //    ModelState.AddModelError(string.Empty, TempData["IsTestUsedInAcademicYearTableErrorMessage"].ToString());
            //}

            return View(data);
        }

        #endregion AcademicYear/List

        #region AcademicYear/Create

        public IActionResult AcademicYearCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcademicYearCreate([Bind("AcademicYearStart, AcademicYearEnd")] AddAcademicYearViewModel addAcademicYearViewModel)
        {
            //var isNotUnique = _context.InterviewTasks.Any(t => t.TaskGroup.TaskGroupName == addInterviewTaskViewModel.TaskGroupName);

            //if (isNotUnique)
            //{
            //    ModelState.AddModelError(string.Empty, "Tokia užduočių grupė jau yra sukurta");
            //}

            if (ModelState.IsValid)
            {                
                    AcademicYear newAcademicYear = new AcademicYear() 
                    { 
                        AcademicYearStart = addAcademicYearViewModel.AcademicYearStart, 
                        AcademicYearEnd = addAcademicYearViewModel.AcademicYearEnd 
                    };
                    _context.AcademicYears.Add(newAcademicYear);
                    _context.SaveChanges();

                return RedirectToAction("AcademicYear");
            }

            return View();
        }

        #endregion AcademicYear/Create

        #region AcademicYear/Delete

        public IActionResult AcademicYearDelete(int id)
        {
            //TODO patikrinimas jei užduotis jau yra priskirta pokalbio šablonui
            //var testConnected = _context.Candidates.Any(x => x.TaskGroup.TaskGroupID == id);

            //if (testConnected)
            //{
            //    TempData["IsTestUsedInAcademicYearTableErrorMessage"] = "Negalima trinti užduočių grupės, nes ji yra susieta su pokalbio užduotimis!";
            //    return RedirectToAction("TaskGroup");
            //}
            //else
            if (ModelState.IsValid)
            {
                var data = _context.AcademicYears.SingleOrDefault(i => i.AcademicYearID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("AcademicYear");
            }
            return RedirectToAction("AcademicYear");
        }

        #endregion AcademicYear/Delete

        //private AddInterviewTaskViewModel GetViewModelWithTaskGroupList()
        //{
        //    var taskGroupsData = _context.TaskGroups.Select(x => new SelectListItem()
        //    {
        //        Value = x.TaskGroupName,
        //        Text = x.TaskGroupName
        //    }).ToList();

        //    var viewModel = new AddInterviewTaskViewModel()
        //    {
        //        TaskGroups = taskGroupsData
        //    };

        //    return viewModel;
        //}

        #endregion AcademicYear

        #region InterviewTemplate

        #region InterviewTemplate/List

        public IActionResult InterviewTemplateList()
        {
            IEnumerable<AddInterviewTemplateViewModel> data = _context.InterviewTemplates.Select(i =>
            new AddInterviewTemplateViewModel()
            {
                InterviewTemplateID = i.InterviewTemplateID,
                AcademicYear = i.AcademicYear
            }).ToList();

            return View(data);
        }

        #endregion InterviewTemplate/List

        #region InterviewTemplate/Create

        public IActionResult InterviewTemplateCreate()
        {
            AddInterviewTemplateViewModel viewModel = GetViewModelWithInterviewTaskList();
            return View("InterviewTemplateCreate", viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult InterviewTemplateCreate(AddInterviewTemplateViewModel addInterviewTemplateViewModel)
        {
            if (addInterviewTemplateViewModel.SelectedInterviewTasks.Any(i => i == null))
            {
                ModelState.AddModelError("SelectedInterviewTasks", "Klausimo laukas turi būti užpildytas");
            }

            AddInterviewTemplateViewModel interviewTemplateViewModel = GetViewModelWithInterviewTaskList(addInterviewTemplateViewModel);

            if (addInterviewTemplateViewModel.SelectedInterviewTasks[0] == null)
            {
                ModelState.AddModelError("SelectedModulesAreNotDistinct", "Bent vienas klausimas turi būti įtrauktas į formą");
                return View(addInterviewTemplateViewModel);
            }

            if (ModelState.IsValid)
            {
                InterviewTemplate newInterviewTemplateRecord = new InterviewTemplate()
                {
                    AcademicYearID = addInterviewTemplateViewModel.AcademicYearID.Value,
                    InterviewTemplateTasks = addInterviewTemplateViewModel.SelectedInterviewTasks.Where(s => s.HasValue).Distinct().Select(s => new InterviewTemplateTask()
                    {
                        InterviewTaskID = s.Value
                    }).ToList()
                };
                _context.InterviewTemplates.Add(newInterviewTemplateRecord);
                _context.SaveChanges();

                return RedirectToAction("InterviewTemplateList");
            }

            return View(interviewTemplateViewModel);
        }

        #endregion InterviewTemplate/Create

        #region InterviewTemplate/Delete

        public IActionResult InterviewTemplateDelete(int id)
        {
            if (ModelState.IsValid)
            {
                var data = _context.InterviewTemplates.SingleOrDefault(i => i.InterviewTemplateID == id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
                return RedirectToAction("InterviewTemplateList");
            }
            return RedirectToAction("InterviewTemplateList");
        }

        #endregion InterviewTemplate/Delete

        private AddInterviewTemplateViewModel GetViewModelWithInterviewTaskList(AddInterviewTemplateViewModel addInterviewTemplateViewModel = null)
        {
            if (addInterviewTemplateViewModel == null) addInterviewTemplateViewModel = new AddInterviewTemplateViewModel() { SelectedInterviewTasks = new int?[] { } };

            addInterviewTemplateViewModel.InterviewTasks = _context.InterviewTasks.Where(i => i.InterviewTaskDescription != null).Select(i => new SelectListItem()
            {
                Value = i.InterviewTaskID.ToString(),
                Text = i.InterviewTaskDescription
            }).ToList();

            addInterviewTemplateViewModel.AcademicYears = _context.AcademicYears.Select(i => new SelectListItem()
            {
                Value = i.AcademicYearID.ToString(),
                Text = i.AcademicYearStart.ToString("yyyy-MM-dd") + "  ||  " + i.AcademicYearEnd.ToString("yyyy-MM-dd")
            }).ToList();

            var selectedInterviewTasks = addInterviewTemplateViewModel.SelectedInterviewTasks.Take(9).ToList();
            while (selectedInterviewTasks.Count < 9)
                selectedInterviewTasks.Add(null);
            addInterviewTemplateViewModel.SelectedInterviewTasks = selectedInterviewTasks.ToArray();

            addInterviewTemplateViewModel.InterviewTasks.Insert(0, new SelectListItem());

            return addInterviewTemplateViewModel;
        }

        #endregion InterviewTemplate


    }
}