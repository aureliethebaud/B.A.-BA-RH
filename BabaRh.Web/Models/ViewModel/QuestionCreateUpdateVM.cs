namespace BabaRh.Web.Models.ViewModel
{
    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;


    public class QuestionCreateUpdateVM
    {
        public QuestionVM Question { get; set; }
        public ReponseVM Reponse { get; set; }

        [Display(Name="Module")]
        public int SelectedModuleId { get; set; }
        [Display(Name = "Niveau")]
        public int SelectedNiveauId { get; set; }
        


        public SelectList AvailableNiveaux { get; set; }
        public SelectList AvailableModules { get; set; }
    }
}