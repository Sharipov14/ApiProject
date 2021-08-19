using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class PossibleProjectervice : IPossibleProjectService
    {
        private ApplicationContext Context;

        public PossibleProjectervice(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<PossibleProject> Get()
        {
            var projects = Context.PossibleProjects.Include(p => p.Project).Include(w => w.Worker).ToList();

            foreach (var project in projects)
            {
                project.ProjectName = project.Project.ProjectName;
                project.WorkerFio = project.Worker.WorkerFio;
            }

            return projects;
        }
        public PossibleProject Get(int id)
        {
            PossibleProject possibleProject = Context.PossibleProjects.Include(p => p.Project).Include(w => w.Worker).FirstOrDefault(x => x.Id == id);

            possibleProject.ProjectName = possibleProject.Project.ProjectName;
            possibleProject.WorkerFio = possibleProject.Worker.WorkerFio;

            return possibleProject;
        }
        public void Create(PossibleProject possibleProject)
        {
            Project project = Context.Projects.FirstOrDefault(x => x.ProjectName == possibleProject.ProjectName);
            Worker worker = Context.Workers.FirstOrDefault(x => x.WorkerFio == possibleProject.WorkerFio);

            if (project != null && worker != null)
            {
                possibleProject.ProjectId = project.ProjectId;
                possibleProject.WorkerId = worker.WorkerId;

                Context.PossibleProjects.Add(possibleProject);
            }
        }
        public void Update(PossibleProject possibleProject)
        {
            Project project = Context.Projects.FirstOrDefault(x => x.ProjectName == possibleProject.ProjectName);
            Worker worker = Context.Workers.FirstOrDefault(x => x.WorkerFio == possibleProject.WorkerFio);

            if (project != null && worker != null)
            {
                possibleProject.ProjectId = project.ProjectId;
                possibleProject.WorkerId = worker.WorkerId;

                Context.PossibleProjects.Update(possibleProject);
            }
        }
        public PossibleProject Delete(int id)
        {
            PossibleProject possibleProject = Get(id);

            if (possibleProject != null)
            {
                Context.PossibleProjects.Remove(possibleProject);
            }
            return possibleProject;
        }
    }
}
