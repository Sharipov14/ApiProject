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
        private IReportService report;

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
                    worker = new WorkerService(context);
                }
                return worker;
            }
        }
        public IDistributionService Distribution {
            get {
                if (distribution == null)
                {
                    distribution = new DistributionsService(context);
                }
                return distribution;
            }
        }
        public IPossibleProjectService PossibleProject {
            get {
                if (possibleProject == null)
                {
                    possibleProject = new PossibleProjectService(context);
                }
                return possibleProject;
            }
        }
        public IReportService Report {
            get {
                if (report == null)
                {
                    //report = new RepotService(context);
                }
                return report;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
