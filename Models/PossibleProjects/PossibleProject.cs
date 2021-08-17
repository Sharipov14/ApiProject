namespace ApiProject.Models
{
    public partial class PossibleProject
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
