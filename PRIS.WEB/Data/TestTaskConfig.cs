using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRIS.WEB.Data
{
    public static class TestTaskConfig
    {
        public static void SeedTasks(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TestTask>().HasData(
            //new TestTask { TaskId = 1 },
            //new TestTask { TaskId = 2 },
            //new TestTask { TaskId = 3 },
            //new TestTask { TaskId = 4 },
            //new TestTask { TaskId = 5 },
            //new TestTask { TaskId = 6 },
            //new TestTask { TaskId = 7 },
            //new TestTask { TaskId = 8 },
            //new TestTask { TaskId = 9 },
            //new TestTask { TaskId = 10 }
            //    );
        }
    }
}
