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
                new Module{ModuleName = "Testuotojai"}
            };
            foreach (Module module in modules)
            {
                context.Modules.Add(module);
            }
            context.SaveChanges();

            var tests = new Test[]
            {
                new Test { CityId = cities.Single(c=>c.CityName == "Vilnius").CityId, DateOfTest = DateTime.Parse("2020-07-30") }               
            };
            foreach (Test test in tests)
            {
                context.Test.Add(test);
            }
            context.SaveChanges();

            var candidates = new Candidate[]
            {
                new Candidate{FirstName = "Vardas", LastName = "Pavardenis", Email = "vardas@meilas.com", PhoneNumber = 860012345}
            };
            foreach (Candidate candidate in candidates)
            {
                context.Candidates.Add(candidate);
            }
            context.SaveChanges();

            var candidateModules = new CandidateModule[]
            {
                new CandidateModule{CandidateID=1,ModuleID=1}
            };
            foreach (CandidateModule candidateModule in candidateModules)
            {
                context.CandidateModules.Add(candidateModule);
            }
            context.SaveChanges();

            var taskGroups = new TaskGroup[]
            {
                new TaskGroup{TaskGroupName="Loginės užduotys"}
            };
            foreach (TaskGroup taskGroup in taskGroups)
            {
                context.TaskGroups.Add(taskGroup);
            }
            context.SaveChanges();
        }
    }
}