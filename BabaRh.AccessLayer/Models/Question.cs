namespace BabaRh.AccessLayer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        public string QuestionLib { get; set; }

        [Required]
        public bool QuestionOuverte { get; set; }

        public int ModuleId { get; set; }
        public int NiveauId { get; set; }

        public Niveau Niveau { get; set; }

        public Module Module { get; set; }
        public ICollection<Reponse> Reponse { get; set; }
        public ICollection<QuizzQuestion> QuizzQuestion { get; set; }
    }
}
