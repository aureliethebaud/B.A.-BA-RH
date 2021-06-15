using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class QuestionVM
    {

        [DataMember]
        public string QuestionId { get; set; }

        [DataMember]
        [Display(Name = "Intitulé")]
        public string QuestionLib { get; set; }

        [DataMember]
        public ModuleVM Module { get; set; }        

        [DataMember]
        public NiveauVM Niveau { get; set; }

        [DataMember]
        [Display(Name = "Question ouverte ?")]
        public bool QuestionOuverte { get; set; }

        [DataMember]
        public List<ReponseVM> Reponses { get; set; }

    }
}