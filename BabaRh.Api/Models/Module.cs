using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Module
    {
        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public string ModuleLib { get; set; }
    }
}