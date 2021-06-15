using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabaRh.Web.Models.ViewModel
{
    public class QuizzCreateUpdateVM
    {
        public QuizzVM Quizz { get; set; }

        public int SelectedCandidatId { get; set; }
        public List<int> SelectedQuestionsIds { get; set; }
        public List<int> SelectedModulesLibs { get; set; }

        public SelectList AvailableCandidats { get; set; }
        public SelectList AvailableQuestions { get; set; }
        public SelectList AvailableModules { get; set; }
    }
}