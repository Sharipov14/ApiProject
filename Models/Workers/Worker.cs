using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Distributions = new HashSet<Distribution>();
            PossibleProjects = new HashSet<PossibleProject>();
            Reports = new HashSet<Report>();
        }

        public int WorkerId { get; set; }
        public string WorkerFio { get; set; }
        public string WorkerPosition { get; set; }

        public virtual ICollection<Distribution> Distributions { get; set; }
        public virtual ICollection<PossibleProject> PossibleProjects { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
