namespace BabaRh.AccessLayer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required, MaxLength(30)]
        public string ModuleLib { get; set; }


        public ICollection<QuizzModule> QuizzModule { get; set; }
        public ICollection<Question> Question { get; set; }

    }
}
