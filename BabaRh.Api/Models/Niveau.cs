﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BabaRh.Api.Models
{
    [DataContract]
    public class Niveau
    {
        [DataMember]
        public int NiveauId { get; set; }

        [DataMember]
        public string NiveauLib { get; set; }
    }
}