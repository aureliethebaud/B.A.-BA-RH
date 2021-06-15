namespace BabaRh.AccessLayer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reponse
    {
        public int ReponseId { get; set; }

        [Required]
        public string ReponseLib { get; set; }
        [Required]
        public bool IsOk { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }


    }
}
