namespace BabaRh.AccessLayer.Models
{
    using System.ComponentModel.DataAnnotations;
   

    public class Candidat
    {
        public int CandidatId { get; set; }

        [Required, MaxLength(30)]
        public string Nom { get; set; }

        [Required, MaxLength(30)]
        public string Prenom { get; set; }

    }
}
