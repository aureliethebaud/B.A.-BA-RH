﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class ModuleVM
    {
        [DataMember]
        public string ModuleLib { get; set; }
    }
}