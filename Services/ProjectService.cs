using ApiProject.IServices;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public class ProjectService : IProjectService
    {
        ApplicationContext db;

        public IEnumerable<Project> Get()
        {
            return db.Projects.ToList();
        }
        public Project Get(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            return project;
        }
        public void Create(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
        }
        public void Update(Project project)
        {
            db.Projects.Update(project);
            db.SaveChanges();
        }
        public Project Delete(int id)
        {
            Project project = Get(id);

            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
            return project;
        }
    }
}
