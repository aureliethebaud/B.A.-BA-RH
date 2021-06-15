using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Quizz
    {
        [DataMember]
        public int QuizzId { get; set; }

        [DataMember]
        public Candidat Candidat { get; set; }

        [DataMember]
        public int Chrono { get; set; }

        [DataMember]
        public int NbQuestion { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public List<Module> Modules { get; set; }

        [DataMember]
        public IEnumerable<Question> Questions { get; set; }
    }
}