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
        public int Id { get; set; }

        [DataMember]
        [Display(Name = "Libellé")]
        public string ReponseLib { get; set; }

        [DataMember]
        [Display(Name = "Réponse juste ?")]
        public bool IsOK { get; set; }

    }
}