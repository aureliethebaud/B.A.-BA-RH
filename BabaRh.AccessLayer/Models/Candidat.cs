using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Candidat
    {
        public int CandidatId { get; set; }

        [Required, MaxLength(30)]
        public string Nom { get; set; }

        [Required, MaxLength(30)]
        public string Prenom { get; set; }

    }
}
