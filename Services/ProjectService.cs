using ApiProject.IServices;
using ApiProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject.Services
{
    public class ProjectService : IProjectService
    {
        private ApplicationContext Context;

        public ProjectService(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<Project> Get()
        {
            return Context.Projects.ToList();
        }
        public Project Get(int id)
        {
            Project project = Context.Projects.FirstOrDefault(x => x.ProjectId == id);
            return project;
        }
        public IEnumerable<string> GetProjectName()
        {
            var projects = Context.Projects.ToList();
            string[] arrProjectName = new string[projects.Count];

            for (int i = 0; i < projects.Count; i++)
            {
                arrProjectName[i] = projects[i].ProjectName;
            }

            return arrProjectName;
        }
        public void Create(Project project)
        {
            Context.Projects.Add(project);
        }
        public void Update(Project project)
        {
            Context.Projects.Update(project);
        }
        public Project Delete(int id)
        {
            Project project = Get(id);

            if (project != null)
            {
                Context.Projects.Remove(project);
            }
            return project;
        }
    }
}
