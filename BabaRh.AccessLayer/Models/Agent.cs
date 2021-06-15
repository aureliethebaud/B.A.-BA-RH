namespace BabaRh.AccessLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Agent
    {
        public int AgentId { get; set; }

        [Required, MaxLength(30)]
        public string Nom { get; set; }

        [Required, MaxLength(30)]
        public string Prenom { get; set; }

        [NotMapped]
        [Required, MinLength(8), MaxLength(12)]
        public string Password { get; set; }
    }
}
