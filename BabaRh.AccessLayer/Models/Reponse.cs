using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Reponse
    {
        public int ReponseId { get; set; }

        [Required]
        public string ReponseLib { get; set; }
        [Required]
        public bool IsOk { get; set; }

        [Required]
        public string QuestionId { get; set; }

        public Question Question { get; set; }


    }
}
