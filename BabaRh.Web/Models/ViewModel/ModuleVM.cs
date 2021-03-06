using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class ModuleVM
    {
        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        [Display (Name="Module")]
        public string ModuleLib { get; set; }

        
    }
}