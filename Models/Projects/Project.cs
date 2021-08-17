using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Project
    {
        public Project()
        {
            Distributions = new HashSet<Distribution>();
            PossibleProjects = new HashSet<PossibleProject>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<Distribution> Distributions { get; set; }
        public virtual ICollection<PossibleProject> PossibleProjects { get; set; }
    }
}
