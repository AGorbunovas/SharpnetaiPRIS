using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;
using System;
using System.Collections.Generic;
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
                new City{CityName = "Kaunas"},
                new City{CityName = "Vilnius"}
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
                    //InterviewTaskDescription = "Ketvirtas klausimas",
                    InterviewTaskDescription = "Ką norėtų veikti baigęs IT akademiją?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 4
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Trecias klausimas",
                    InterviewTaskDescription = "Ko tikisi iš IT akademijos?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 3
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Antras klausimas",
                    InterviewTaskDescription = "Kokios IT veiklos sritys labiausiai domina?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 2
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Pirmas klausimas",
                    InterviewTaskDescription = "Ar dirba/studijuoja? Jei planuoja tą tęsti ir mokymosi metu – kiek norės skirti laiko kitoms veikloms, ir kaip tikisi suderinti (studijas/ darbą ir mokslus akademijoje)?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 1
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Penktas klausimas",
                    InterviewTaskDescription = "Kas motyvuoja tapti testuotoju/-a? Kodėl nori testuoti programas?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 5
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Šeštas klausimas",
                    InterviewTaskDescription = "Kaip domisi IT? Skaito knygas/forumus?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 6
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Septintas klausimas",
                    InterviewTaskDescription = "Ar kažką kūrė ar testavo savarankiškai? Žaidimus/puslapius/programėles?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 7
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Aštuntas klausimas",
                    InterviewTaskDescription = "Ar mokėsi mokykloje informatiką? Koks lygis? (optional)",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 8
                },
                new InterviewTask
                {
                    //InterviewTaskDescription = "Devintas klausimas",
                    InterviewTaskDescription = "When was the last time you used English - speaking, writing, reading?",
                    Date = DateTime.Parse("2020-07-01"),
                    Position = 9
                }
            );
            context.SaveChanges();

            var taskResultLimit = new TaskResultLimit[]
            {
                new TaskResultLimit
                {
                    //TaskResultLimitId = 10,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Programavimo pagrindai").TaskGroupID,
                    MaxValue = 4,
                    Position = 10,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 9,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Programavimo pagrindai").TaskGroupID,
                    MaxValue = 2,
                    Position = 9,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 8,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 8,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 7,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 7,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 6,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 6,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 5,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Loginės užduotys").TaskGroupID,
                    MaxValue = 1,
                    Position = 5,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 4,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 4,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 3,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 3,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 2,
                    TaskGroupID = taskGroups.Single(t => t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 2,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
                new TaskResultLimit
                {
                    //TaskResultLimitId = 1,
                    TaskGroupID = taskGroups.Single(t=>t.TaskGroupName == "Kompiuteriniai pagrindai").TaskGroupID,
                    MaxValue = 1,
                    Position = 1,
                    Date = DateTime.Now,
                    AcademicYearID = 1
                },
            };
            foreach (TaskResultLimit limits in taskResultLimit)
            {
                context.TaskResultLimits.Add(limits);
            }
            context.SaveChanges();

            var tests = new Test[]
            {
                new Test
                {
                    CityId = cities.Single(c=>c.CityName == "Vilnius").CityId,
                    DateOfTest = DateTime.Parse("2020-08-10"),
                    AcademicYearID = academicYears.Single(a=>a.AcademicYearID == 1).AcademicYearID
                },
                new Test
                {
                    CityId = cities.Single(c=>c.CityName == "Kaunas").CityId,
                    DateOfTest = DateTime.Parse("2020-08-10"),
                    AcademicYearID = academicYears.Single(a=>a.AcademicYearID == 1).AcademicYearID
                }
            };

            foreach (Test test in tests)
            {
                context.Test.Add(test);
            }
            context.SaveChanges();

            var candidates = new Candidate[]
            {
                new Candidate
                {
                    FirstName = "Tomas", 
                    LastName = "Tomulevičius", 
                    Email = "tomas@tomas.com", 
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Ona",
                    LastName = "Petrutė",
                    Email = "ona@ona.com",
                    PhoneNumber = 860012345,
                    Gender = "Female",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
                new Candidate
                {
                    FirstName = "Kęstas",
                    LastName = "Puteikis",
                    Email = "kestas@kestas.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Petras",
                    LastName = "Petrauskas",
                    Email = "petras@petras.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Rimas",
                    LastName = "Buldeikis",
                    Email = "rimas@rimas.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
                new Candidate
                {
                    FirstName = "Rita",
                    LastName = "Petrulytė",
                    Email = "rita@rita.com",
                    PhoneNumber = 860012345,
                    Gender = "Female",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Eimantas",
                    LastName = "Rudikis",
                    Email = "eimantas@eimantas.com",
                    PhoneNumber = 860012345,
                    //Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
                new Candidate
                {
                    FirstName = "Lina",
                    LastName = "Krulienė",
                    Email = "lina@lina.com",
                    PhoneNumber = 860012345,
                    Gender = "Female",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Linas",
                    LastName = "Kauliauskas",
                    Email = "linas@linas.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 2).TestId
                },
                new Candidate
                {
                    FirstName = "Rytis",
                    LastName = "Bendorius",
                    Email = "rytis@rytis.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
                new Candidate
                {
                    FirstName = "Ąžuolas",
                    LastName = "Kvedaras",
                    Email = "vardas@meilas.com",
                    PhoneNumber = 860012345,
                    Gender = "Male",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
                new Candidate
                {
                    FirstName = "Marytė",
                    LastName = "Rasaitė",
                    Email = "marytė@marytė.com",
                    PhoneNumber = 860012345,
                    //Gender = "Female",
                    TestId = tests.Single(t => t.TestId == 1).TestId
                },
            };
            foreach (Candidate candidate in candidates)
            {
                context.Candidates.Add(candidate);
            }
            context.SaveChanges();

            var candidateModules = new CandidateModule[]
            {
                new CandidateModule
                {
                    CandidateID = 1,
                    ModuleID = 1,
                    OrderNr = 0
                    //Nenurodyta
                },
                new CandidateModule
                {
                    CandidateID = 2,
                    ModuleID = 2,
                    OrderNr = 0
                    //Java
                }, new CandidateModule
                {
                    CandidateID = 2,
                    ModuleID = 3,
                    OrderNr = 1
                    //.Net programuotojai
                },
                new CandidateModule
                {
                    CandidateID = 2,
                    ModuleID = 4,
                    OrderNr = 2
                    //Testuotojai
                },
                new CandidateModule
                {
                    CandidateID = 3,
                    ModuleID = 2,
                    OrderNr = 0
                    //Java
                }, new CandidateModule
                {
                    CandidateID = 3,
                    ModuleID = 3,
                    OrderNr = 1
                    //.Net programuotojai
                },
                new CandidateModule
                {
                    CandidateID = 4,
                    ModuleID = 1,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 5,
                    ModuleID = 4,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 5,
                    ModuleID = 3,
                    OrderNr = 1
                },
                new CandidateModule
                {
                    CandidateID = 6,
                    ModuleID = 3,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 7,
                    ModuleID = 4,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 8,
                    ModuleID = 2,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 8,
                    ModuleID = 3,
                    OrderNr = 1
                },
                new CandidateModule
                {
                    CandidateID = 9,
                    ModuleID = 3,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 9,
                    ModuleID = 2,
                    OrderNr = 1
                },
                new CandidateModule
                {
                    CandidateID = 10,
                    ModuleID = 4,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 11,
                    ModuleID = 3,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 12,
                    ModuleID = 2,
                    OrderNr = 0
                },
                new CandidateModule
                {
                    CandidateID = 12,
                    ModuleID = 4,
                    OrderNr = 1
                },
                new CandidateModule
                {
                    CandidateID = 12,
                    ModuleID = 3,
                    OrderNr = 2
                }
            };
            foreach (CandidateModule candidateModule in candidateModules)
            {
                context.CandidateModules.Add(candidateModule);
            }
            context.SaveChanges();
        }
    }
}