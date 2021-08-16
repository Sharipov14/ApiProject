using Microsoft.EntityFrameworkCore;
using ApiProject.Models.Projects;
using ApiProject.Models.Workers;
using ApiProject.Models.Distributions;
using ApiProject.Models.PossibleProjects;
using ApiProject.Models.Report;

namespace HelloAngularApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<PossibleProject> PossibleProjects { get; set; }
        public DbSet<Report> Report { get; set; }
    }
}