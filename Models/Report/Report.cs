using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string WorkerPosition { get; set; }
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
        public int _6 { get; set; }
        public int _7 { get; set; }
        public int _8 { get; set; }
        public int _9 { get; set; }
        public int _10 { get; set; }
        public int _11 { get; set; }
        public int _12 { get; set; }
        public int _13 { get; set; }
        public int _14 { get; set; }
        public int _15 { get; set; }
        public int _16 { get; set; }
        public int _17 { get; set; }
        public int _18 { get; set; }
        public int _19 { get; set; }
        public int _20 { get; set; }
        public int _21 { get; set; }
        public int _22 { get; set; }
        public int _23 { get; set; }
        public int _24 { get; set; }
        public int _25 { get; set; }
        public int _26 { get; set; }
        public int _27 { get; set; }
        public int _28 { get; set; }
        public int _29 { get; set; }
        public int _30 { get; set; }
        public int _31 { get; set; }

        [NotMapped]
        public int[] Array = new int[31];

        [JsonIgnore]
        public virtual Worker Worker { get; set; }
    }
}
