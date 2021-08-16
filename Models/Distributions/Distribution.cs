using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models.Distributions
{
    public class Distribution
    {
        [Key]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateStart { get; set; }
        public int Hours { get; set; }
    }
}
