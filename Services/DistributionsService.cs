using ApiProject.Models;
using System.Collections.Generic;
using System.Linq;
using ApiProject.IServices;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class DistributionsService : IDistributionService
    {
        private ApplicationContext Context;

        public DistributionsService(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<Distribution> Get()
        {
            var distributions = Context.Distributions.Include(p => p.Project).Include(w => w.Worker).ToList();

            foreach (var distribution in distributions)
            {
                distribution.ProjectName = distribution.Project.ProjectName;
                distribution.WorkerFio = distribution.Worker.WorkerFio;
            }

            return distributions;
        }
        public Distribution Get(int id)
        {
            Distribution distribution = Context.Distributions.Include(p => p.Project).Include(w => w.Worker).FirstOrDefault(x => x.Id == id);

            distribution.ProjectName = distribution.Project.ProjectName;
            distribution.WorkerFio = distribution.Worker.WorkerFio;

            return distribution;
        }
        public void Create(Distribution distribution)
        {
            Project project = Context.Projects.FirstOrDefault(x => x.ProjectName == distribution.ProjectName);
            Worker worker = Context.Workers.FirstOrDefault(x => x.WorkerFio == distribution.WorkerFio);

            if (project != null && worker != null)
            {
                distribution.ProjectId = project.ProjectId;
                distribution.WorkerId = worker.WorkerId;

                Context.Distributions.Add(distribution);
            }
        }
        public void Update(Distribution distribution)
        {
            Project project = Context.Projects.FirstOrDefault(x => x.ProjectName == distribution.ProjectName);
            Worker worker = Context.Workers.FirstOrDefault(x => x.WorkerFio == distribution.WorkerFio);

            if (project != null && worker != null)
            {
                distribution.ProjectId = project.ProjectId;
                distribution.WorkerId = worker.WorkerId;

                Context.Distributions.Update(distribution);
            }
        }
        public Distribution Delete(int id)
        {
            Distribution distribution = Get(id);

            if (distribution != null)
            {
                Context.Distributions.Remove(distribution);
            }
            return distribution;
        }
    }
}
