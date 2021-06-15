namespace BabaRh.AccessLayer.Models
{
    using System.Collections.Generic;
    

    public class Quizz
    {
        public int QuizzId { get; set; }

        public int Chrono { get; set; }

        public int NbQuestion { get; set; }

        public string Url { get; set; }

        public int CandidatId { get; set; }
        public Candidat Candidat { get; set; }

        public ICollection<QuizzModule> QuizzModule { get; set; }

        public ICollection<QuizzQuestion> QuizzQuestion { get; set; }

    }
}
