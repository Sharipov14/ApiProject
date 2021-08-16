using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models.PossibleProjects
{
    public class PossibleProject
    {
        [Key]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ProjectId { get; set; }
    }
}
