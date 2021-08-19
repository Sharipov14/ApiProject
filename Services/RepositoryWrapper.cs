using ApiProject.IServices;
using ApiProject.Models;

namespace ApiProject.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext context;
        private IProjectService project;
        private IWorkerService worker;
        private IDistributionService distribution;
        private IPossibleProjectService possibleProject;
        private IReportService retport;

        public RepositoryWrapper(ApplicationContext _context)
        {
            context = _context;
        }

        public IProjectService Project {
            get {
                if (project == null)
                {
                    project = new ProjectService(context);
                }
                return project;
            }
        }
        public IWorkerService Worker { 
            get {
                if (worker == null)
                {
                    //worker = new WorkerService(context);
                }
                return worker;
            }
        }
        public IDistributionService Distributions {
            get {
                return distribution;
            }
        }
        public IPossibleProjectService PossibleProject
        {
            get
            {
                return possibleProject;
            }
        }
        public IReportService Report
        {
            get
            {
                return retport;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
