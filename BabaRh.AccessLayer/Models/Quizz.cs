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

        public int CandidatId { get; set; }

        public DateTime Timer { get; set; }

        public int NbQuestion { get; set; }

        public string Url { get; set; }


        public Candidat Candidat { get; set; }

        public ICollection<QuizzModule> QuizzModule { get; set; }

        public ICollection<QuizzQuestion> QuizzQuestion { get; set; }

    }
}
