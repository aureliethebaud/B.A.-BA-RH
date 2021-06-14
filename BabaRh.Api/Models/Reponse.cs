using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Reponse
    {
        [DataMember]
        public int ReponseId { get; set; }

        [DataMember]
        public string ReponseLib { get; set; }

        [DataMember]
        public bool IsOk { get; set; }        

        [DataMember]
        public Question Question { get; set; }

    }
}