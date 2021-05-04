using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.Models
{
    public class Agent
    {
        public int AgentId { get; set;}

        [Required, MaxLength(30)]
        public string Nom { get; set; }

        [Required, MaxLength(30)]
        public string Prenom { get; set; }

        [Required, MinLength(8), MaxLength(12)]
        public string Password { get; set; }
    }
}
