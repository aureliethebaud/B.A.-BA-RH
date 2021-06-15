namespace BabaRh.AccessLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizzQuestion
    {
        [Key, Column(Order = 1)]
        public int QuizzId { get; set; }
        [Key, Column(Order = 2)]
        public int QuestionId { get; set; }

        public Quizz Quizz { get; set; }
        public Question Question { get; set; }
    }
}
