using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.IServices
{
    public interface IRepositoryWrapper
    {
        IProjectService Project { get; }
        IWorkerService Worker { get; }
        IDistributionService Distributions { get; }
        IPossibleProjectService PossibleProject { get; }
        IReportService Report { get; }
        void Save();
    }
}
