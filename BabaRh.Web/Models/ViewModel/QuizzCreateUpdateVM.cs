using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabaRh.Web.Models.ViewModel
{
    public class QuizzCreateUpdateVM
    {
        [Display(Name="Quiz")]
        public QuizzVM Quizz { get; set; }

        [Display(Name = "Candidat")]
        public int SelectedCandidatId { get; set; }
        [Display(Name = "Questions")]
        public List<int> SelectedQuestionsIds { get; set; }
        [Display(Name = "Modules")]
        public List<int> SelectedModulesLibs { get; set; }

        public SelectList AvailableCandidats { get; set; }
        public SelectList AvailableQuestions { get; set; }
        public SelectList AvailableModules { get; set; }
    }
}