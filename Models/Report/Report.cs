using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models.Report
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string Position { get; set; }
        public int[] Month = new int[31];
    }
}
