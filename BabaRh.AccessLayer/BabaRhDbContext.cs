namespace BabaRh.AccessLayer
{
    using BabaRh.AccessLayer.Models;
    using System.Data.Entity;

    public class BabaRhDbContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « BabaRhDbContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « BabaRh.AccessLayer.BabaRhDbContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « BabaRhDbContext » dans le fichier de configuration de l'application.
        public BabaRhDbContext()
            : base("name=BabaRhDbContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<Quizz> Quizzs { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reponse> Reponses { get; set; }
        public virtual DbSet<QuizzModule> QuizzModules { get; set; }
        public virtual DbSet<Niveau> Niveaux { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}