namespace BabaRh.AccessLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizzModule
    {
        [Key]
        [Column(Order = 1)]
        public int QuizzId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ModuleId { get; set; }

        public Quizz Quizz { get; set; }
        public Module Module { get; set; }

    }
}
