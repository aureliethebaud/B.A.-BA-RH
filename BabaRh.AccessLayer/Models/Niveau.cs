namespace BabaRh.AccessLayer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Niveau
    {
        public int NiveauId { get; set; }

        [Required, MaxLength(30)]
        public string NiveauLib { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
