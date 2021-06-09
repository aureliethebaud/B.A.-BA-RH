using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]        
        public string QuestionLib { get; set; }

        [Required]        
        public string ModuleLib { get; set; }
        
        [Required]
        public Niveau Niveau { get; set; }

        [Required]
        public bool QuestionOuverte { get; set; }


        public Module Module { get; set; }
        public ICollection<Reponse> Reponse { get; set; }
        public ICollection<Quizz> Quizz { get; set; }
    }
}
