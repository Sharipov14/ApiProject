using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models.Workers
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
    }
}
