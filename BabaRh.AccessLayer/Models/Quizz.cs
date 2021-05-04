using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Quizz
    {
        public int QuizzId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int CandidatId { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int QuestionId { get; set; }

        public ICollection<Candidat> Candidat { get; set; }
        public ICollection<Question> Question { get; set; }

    }
}
