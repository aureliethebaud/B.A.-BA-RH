using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class QuizzVM
    {
        [DataMember]
        public int QuizzId { get; set; }

        [DataMember]
        public CandidatVM Candidat { get; set; }

        [DataMember]
        public int Chrono { get; set; }

        [DataMember]
        public int NbQuestion { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public List<ModuleVM> Modules { get; set; }

        [DataMember]
        public List<QuestionVM> Questions { get; set; }
    }
}