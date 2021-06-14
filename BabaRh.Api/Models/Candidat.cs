using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Candidat
    {
        [DataMember(Name = "CandidatId")]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Prenom { get; set; }
    }
}