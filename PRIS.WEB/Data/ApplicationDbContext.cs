using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRIS.WEB.Data.Models;
using PRIS.WEB.Models;

namespace PRIS.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Test> Test { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateModule> CandidateModules { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<InterviewTask> InterviewTasks { get; set; }
        public DbSet<TaskResultLimit> TaskResultLimits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<CandidateModule>().ToTable("CandidateModule");
            modelBuilder.Entity<TaskGroup>().ToTable("TaskGroups");
            modelBuilder.Entity<TaskResultLimit>().ToTable("TaskResultLimits");
            modelBuilder.Entity<InterviewTask>().ToTable("InterviewTask");

            modelBuilder.Entity<CandidateModule>()
                .HasKey(candidateModule => new { candidateModule.CandidateID, candidateModule.ModuleID });

            //https://stackoverflow.com/questions/50785009/how-to-seed-an-admin-user-in-ef-core-2-1-0
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UsersWithRolesConfiguration());

            modelBuilder.SeedTasks();
        }
    }
}
