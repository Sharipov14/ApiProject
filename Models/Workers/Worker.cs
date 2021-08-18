using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Distribution> Distributions { get; set; }
        [JsonIgnore]
        public virtual ICollection<PossibleProject> PossibleProjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
