using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabaRh.Web.Models.ViewModel
{

    public class QuizzVM
    {
        public int QuizzId { get; set; }

        public int CandidatId { get; set; }

        public DateTime Timer { get; set; }

        public int NbQuestion { get; set; }

        public string Url { get; set; }

        public List<ModuleVM> Modules { get; set; }

    }
}