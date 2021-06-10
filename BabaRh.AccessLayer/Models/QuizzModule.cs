using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class QuizzModule
    {
        [Key]
        [Column(Order = 1)]
        public int QuizzId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ModuleLib { get; set; }

        public Quizz Quizz { get; set; }
        public Module Module { get; set; }

    }
}
