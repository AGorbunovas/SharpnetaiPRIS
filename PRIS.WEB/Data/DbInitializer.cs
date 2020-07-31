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

            //Kandidato testo rezultatų užpildymas
            var taskResults = new TaskResult[]
            {
                //Candidate 3
                new TaskResult
                {
                    Value = 3.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 9).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 2,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 8).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 3).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 0.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 2).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 0.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 1).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 10).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 0.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 7).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 0.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 6).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 0.5,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 5).TaskResultLimitId,
                    CandidateId = 3
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 4).TaskResultLimitId,
                    CandidateId = 3
                },
                //Candidate 6
                new TaskResult
                {
                    Value = 3,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 9).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 2,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 8).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 7).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 6).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 5).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 4).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 3).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 2).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 1).TaskResultLimitId,
                    CandidateId = 6
                },
                new TaskResult
                {
                    Value = 1,
                    TaskResultLimitId = taskResultLimit.Single(t => t.TaskResultLimitId == 10).TaskResultLimitId,
                    CandidateId = 6
                },
            };

            foreach (TaskResult taskResult in taskResults)
            {
                context.TaskResult.Add(taskResult);
            }
            context.SaveChanges();

            //Kandidato pokalbio rezultatų užpildymas
            var interviewResults = new InterviewResult[]
           {
                new InterviewResult
                {
                    GeneralComment = "Pasirodė gerai. Galima imti.",
                    Value = 8,
                    CandidateId = 1
                },
                new InterviewResult
                {
                    GeneralComment = "Pasirodė nelabai. ???",
                    Value = 3,
                    CandidateId = 3
                }
           };

            foreach (InterviewResult interviewResult in interviewResults)
            {
                context.InterviewResults.Add(interviewResult);
            }
            context.SaveChanges();

            //Kandidato pokalbio klausimyno rezultatų užpildymas
            var interviewQuestionsAnswers = new InterviewQuestionsAnswers[]
           {
               //Rytis Bendorius
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Good.",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 1).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Taip",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 8).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Ne",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 7).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 6).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 5).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Dirbti programuotoju",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 4).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Žinių",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 3).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Programavimas",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 2).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 1,
                    Comment = "Dirba pusę etato. ",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 1).InterviewTaskID
                },

                //Lina Krulienė
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "A long time ago...",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 9).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Bijojau kaip velnio.",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 8).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Taip",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 7).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Pokemonai",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 6).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Galima į valias prisižaisti žaidimų",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 5).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Gaudyti testus",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 4).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Išmokins gerai testuoti žaidimus",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 3).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Žaidimai",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 2).InterviewTaskID
                },
                new InterviewQuestionsAnswers
                {
                    CandidateID = 3,
                    Comment = "Kelios kėdės geriu nei viena",
                    InterviewTaskID = context.InterviewTasks.Single(i=>i.InterviewTaskID == 1).InterviewTaskID
                }
           };

            foreach (InterviewQuestionsAnswers interviewQuestionAnswer in interviewQuestionsAnswers)
            {
                context.InterviewQuestionsAnswers.Add(interviewQuestionAnswer);
            }
            context.SaveChanges();
        }
    }
}