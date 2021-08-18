using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    public partial class Distribution
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateStart { get; set; }
        public int Hours { get; set; }

        [NotMapped]
        public string WorkerFio { get; set; }
        [NotMapped]
        public string ProjectName { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }
        [JsonIgnore]
        public virtual Worker Worker { get; set; }
    }
}
