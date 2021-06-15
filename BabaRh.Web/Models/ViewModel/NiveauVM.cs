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
        public string NiveauLib { get; set; }

    }
}