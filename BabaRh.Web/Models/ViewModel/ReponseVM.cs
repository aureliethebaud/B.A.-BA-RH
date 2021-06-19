using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class ReponseVM
    {
        [DataMember]
        public int ReponseId { get; set; }

        [DataMember]
        [Display(Name = "Intitulé de la question")]
        public string ReponseLib { get; set; }

        [DataMember]
        [Display(Name = "Réponse vraie ?")]
        public bool IsOK { get; set; }

        [DataMember]
        public int QuestionId { get; set; }


    }
}