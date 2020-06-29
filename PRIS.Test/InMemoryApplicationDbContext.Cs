using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRIS.Test
{
    internal static class InMemoryApplicationDbContext
    {
        internal static ApplicationDbContext GetInMemoryApplicationDbContext()
        {
            //read more: https://gunnarpeipman.com/aspnet-core-ef-inmemory-database/
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }
    }
}
