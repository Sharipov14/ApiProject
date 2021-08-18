using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Distribution> Distributions { get; set; }
        [JsonIgnore]
        public virtual ICollection<PossibleProject> PossibleProjects { get; set; }
    }
}
