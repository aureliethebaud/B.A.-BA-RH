using System;
using System.Collections.Generic;
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
        public string ReponseLib { get; set; }

        [DataMember]
        public bool IsOK { get; set; }

    }
}