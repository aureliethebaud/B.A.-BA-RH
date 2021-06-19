using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace BabaRh.Web.Models.ViewModel
{
    [DataContract]
    public class NiveauVM
    {
        [DataMember]
        public int NiveauId { get; set; }

        [DataMember]
        [Display(Name = "Niveau")]
        [Required(ErrorMessage = "Le libellé du niveau est requis")]
        public string NiveauLib { get; set; }

    }
}