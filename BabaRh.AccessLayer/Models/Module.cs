using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Module
    {
        [Key]
        [MaxLength(30)]
        public string ModuleLib { get; set; }


        public ICollection<Quizz> Quizz { get; set; }
        public ICollection<Question> Question { get; set; }

    }
}
