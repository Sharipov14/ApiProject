using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models.Projects
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}
