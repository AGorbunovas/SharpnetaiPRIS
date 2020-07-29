using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Linq;

namespace PRIS.WEB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Modules.Any())
            {
                return;
            }

            var taskGroups = new TaskGroup[]
            {
                new TaskGroup{TaskGroupName="Loginės užduotys"},
                new TaskGroup{TaskGroupName="Kompiuteriniai pagrindai"},
                new TaskGroup{TaskGroupName="Programavimo pagrindai"}
            };
            foreach (TaskGroup taskGroup in taskGroups)
            {
                context.TaskGroups.Add(taskGroup);
            }
            context.SaveChanges();

            var cities = new City[]
            {
                new City{CityName = "Vilnius"},
                new City{CityName = "Kaunas"}
            };
            foreach (City city in cities)
            {
                context.Cities.Add(city);
            }
            context.SaveChanges();

            var modules = new Module[]
            {
                new Module{ModuleName = ".NET programuotojai"},
                new Module{ModuleName = "Java programuotojai"},
                new Module{ModuleName = "Nenurodyta"},
                new Module{ModuleName = "Testuotojai"}
            };
            foreach (Module module in modules)
            {
                context.Modules.Add(module);
            }
            context.SaveChanges();

            var academicYears = new AcademicYear[]
            {
                new AcademicYear { AcademicYearStart = DateTime.Parse("2020-09-01"), AcademicYearEnd = DateTime.Parse("2021-05-31")}
            };
            foreach (AcademicYear academicYear in academicYears)
            {
                context.AcademicYears.Add(academicYear);
            }
            context.SaveChanges();

            context.InterviewTasks.AddRange(
                new InterviewTask
            {
                InterviewTaskDescription = "Pirmas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 1
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Antras klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 2
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Trecias klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 3
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Ketvirtas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 4
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Penktas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 5
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Šeštas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 6
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Septintas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 7
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Aštuntas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 8
            },
                new InterviewTask
            {
                InterviewTaskDescription = "Devintas klausimas",
                Date = DateTime.Parse("2020-07-01"),
                Position = 9
            }
            );
            context.SaveChanges();

            context.TaskResultLimits.AddRange(
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t=>t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 1,
                    Date = DateTime.Now

                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 2,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 3,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 4,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 5,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 6,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 7,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 8,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Programavimo pagrindai").TaskGroupID,
                    MaxValue = 2,
                    Position = 9,
                    Date = DateTime.Now
                },   
                new TaskResultLimit
                {
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Programavimo pagrindai").TaskGroupID,
                    MaxValue = 4,
                    Position = 10,
                    Date = DateTime.Now
                }        
            );
            context.SaveChanges();


            //TODO need corrections for Candidate, Test and InterviewTask

            var tests = new Test[]
            {
                new Test
                {
                    CityId = cities.Single(c=>c.CityName == "Vilnius").CityId,
                    DateOfTest = DateTime.Now,
                    AcademicYearID = academicYears.Single(a=>a.AcademicYearID == 0).AcademicYearID
                },
                new Test
                {
                    CityId = cities.Single(c=>c.CityName == "Kaunas").CityId,
                    DateOfTest = DateTime.Now,
                    AcademicYearID = academicYears.Single(a=>a.AcademicYearID == 0).AcademicYearID
                }
            };

            foreach (Test test in tests)
            {
                context.Test.Add(test);
            }
            context.SaveChanges();

            var candidates = new Candidate[]
            {
                new Candidate{FirstName = "Vardas", LastName = "Pavardenis", Email = "vardas@meilas.com", PhoneNumber = 860012345, TestId = 0, Gender = "Male"},
                new Candidate{FirstName = "Antanas", LastName = "Anatanaitis", Email = "antanas@antanas.com", PhoneNumber = 860012345, TestId = 0, Gender = "Male"},
                new Candidate{FirstName = "Ona", LastName = "Petrutė", Email = "ona@ona.com", PhoneNumber = 860012345, TestId = 1, Gender = "Female"},
                new Candidate{FirstName = "Kurpis", LastName = "Kurpaitis", Email = "kurpis@kurpis.com", PhoneNumber = 860012345, TestId = 1, Gender = "Male"}
            };
            foreach (Candidate candidate in candidates)
            {
                context.Candidates.Add(candidate);
            }
            context.SaveChanges();

            var candidateModules = new CandidateModule[]
            {
                new CandidateModule{CandidateID = 0,ModuleID = 0},
                new CandidateModule{CandidateID = 0,ModuleID = 3},
                new CandidateModule{CandidateID = 1,ModuleID = 2},
                new CandidateModule{CandidateID = 2,ModuleID = 1},
                new CandidateModule{CandidateID = 3,ModuleID = 0},
                new CandidateModule{CandidateID = 3,ModuleID = 3},
                new CandidateModule{CandidateID = 3,ModuleID = 1}
            };
            foreach (CandidateModule candidateModule in candidateModules)
            {
                context.CandidateModules.Add(candidateModule);
            }
            context.SaveChanges();
        }
    }
}