using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class CandidatVM
    {
        [DataMember(Name = "CandidatId")]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le nom du candidat est requis")]
        public string Nom { get; set; }

        [DataMember]
        [Display(Name="Prénom")]
        [Required(ErrorMessage = "Le prénom du candidat est requis")]
        public string Prenom { get; set; }
    }
}