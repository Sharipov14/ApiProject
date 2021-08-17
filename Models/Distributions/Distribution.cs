using System;

namespace ApiProject.Models
{
    public partial class Distribution
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateStart { get; set; }
        public int Hours { get; set; }

        public virtual Project Project { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
