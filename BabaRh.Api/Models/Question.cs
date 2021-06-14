using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int QuestionId { get; set; }

        [DataMember]
        public string QuestionLib { get; set; }

        [DataMember]
        public string ModuleLib { get; set; }

        [DataMember]
        public Niveau Niveau { get; set; }

        [DataMember]
        public bool QuestionOuverte { get; set; }

        [DataMember]
        public List<Reponse> Reponses { get; set; }

    }
}