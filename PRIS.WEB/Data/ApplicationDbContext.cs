using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Models;

namespace PRIS.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Test> Test { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<City> Cities { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        
    }
}
